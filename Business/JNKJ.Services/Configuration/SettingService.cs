using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JNKJ.Core;
using JNKJ.Domain;
using JNKJ.Cache.Caching;
using JNKJ.Core.Data;
using JNKJ.Domain.Configuration;

namespace JNKJ.Services.Configuration
{
    /// <summary>
    /// Setting manager
    /// </summary>
    public partial class SettingService : ISettingService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        private const string SETTINGS_ALL_KEY = "JNKJ.setting.all";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string SETTINGS_PATTERN_KEY = "JNKJ.setting.";

        #endregion

        #region Fields

        private readonly IRepository<Setting> _settingRepository;
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="eventPublisher">Event publisher</param>
        /// <param name="settingRepository">Setting repository</param>
        public SettingService(ICacheManager cacheManager, IRepository<Setting> settingRepository)
        {
            this._cacheManager = cacheManager;
            this._settingRepository = settingRepository;
        }

        #endregion

        #region Nested classes

        [Serializable]
        public class SettingForCaching
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public int SiteId { get; set; }
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Gets all settings
        /// </summary>
        /// <returns>Setting collection</returns>
        protected virtual IDictionary<string, IList<SettingForCaching>> GetAllSettingsCached()
        {
            //cache
            string key = string.Format(SETTINGS_ALL_KEY);
            return _cacheManager.Get(key, () =>
            {
                //we use no tracking here for performance optimization
                //anyway records are loaded only for read-only operations
                var query = from s in _settingRepository.TableNoTracking
                            orderby s.Name, s.SiteId
                            select s;
                var settings = query.ToList();
                var dictionary = new Dictionary<string, IList<SettingForCaching>>();
                foreach (var s in settings)
                {
                    var resourceName = s.Name.ToLowerInvariant();
                    var settingForCaching = new SettingForCaching()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Value = s.Value,
                        SiteId = s.SiteId
                    };
                    if (!dictionary.ContainsKey(resourceName))
                    {
                        //first setting
                        dictionary.Add(resourceName, new List<SettingForCaching>()
                        {
                            settingForCaching
                        });
                    }
                    else
                    {
                        //already added
                        //most probably it's the setting with the same name but for some certain store (SiteId > 0)
                        dictionary[resourceName].Add(settingForCaching);
                    }
                }
                return dictionary;
            });
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a setting
        /// </summary>
        /// <param name="setting">Setting</param>
        /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
        public virtual bool InsertSetting(Setting setting, bool clearCache = true)
        {
            if (setting == null)
                throw new ArgumentNullException("setting");

            bool result = _settingRepository.Insert(setting);

            if (result)
            {            //cache
                if (clearCache)
                    _cacheManager.RemoveByPattern(SETTINGS_PATTERN_KEY);
                //event notification
            }
            return result;

        }

        /// <summary>
        /// Updates a setting
        /// </summary>
        /// <param name="setting">Setting</param>
        /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
        public virtual bool UpdateSetting(Setting setting, bool clearCache = true)
        {
            if (setting == null)
                throw new ArgumentNullException("setting");

            bool result = _settingRepository.Update(setting);

            if (result)
            {
                //cache
                if (clearCache)
                    _cacheManager.RemoveByPattern(SETTINGS_PATTERN_KEY);
            }
            return result;
        }

        /// <summary>
        /// Deletes a setting
        /// </summary>
        /// <param name="setting">Setting</param>
        public virtual bool DeleteSetting(Setting setting)
        {
            if (setting == null)
                throw new ArgumentNullException("setting");

            bool result = _settingRepository.Delete(setting);

            if (result)
            {
                //cache
                _cacheManager.RemoveByPattern(SETTINGS_PATTERN_KEY);

            }
            return result;
        }

        /// <summary>
        /// Gets a setting by identifier
        /// </summary>
        /// <param name="settingId">Setting identifier</param>
        /// <returns>Setting</returns>
        public virtual Setting GetSettingById(Guid settingId)
        {
            if (string.IsNullOrEmpty(settingId.ToString()))
                return null;

            return _settingRepository.GetById(settingId);
        }

        /// <summary>
        /// Get setting value by key
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="SiteId">Store identifier</param>
        /// <param name="loadSharedValueIfNotFound">A value indicating whether a shared (for all stores) value should be loaded if a value specific for a certain is not found</param>
        /// <returns>Setting value</returns>
        public virtual T GetSettingByKey<T>(string key, T defaultValue = default(T),
            int SiteId = 0, bool loadSharedValueIfNotFound = false)
        {
            if (string.IsNullOrEmpty(key))
                return defaultValue;

            var settings = GetAllSettingsCached();
            key = key.Trim().ToLowerInvariant();
            if (settings.ContainsKey(key))
            {
                var settingsByKey = settings[key];
                var setting = settingsByKey.FirstOrDefault(x => x.SiteId == SiteId);

                //load shared value?
                if (setting == null && SiteId > 0 && loadSharedValueIfNotFound)
                    setting = settingsByKey.FirstOrDefault(x => x.SiteId == 0);

                if (setting != null)
                    return CommonHelper.To<T>(setting.Value);
            }

            return defaultValue;
        }

        /// <summary>
        /// Set setting value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="SiteId">Store identifier</param>
        /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
        public virtual bool SetSetting<T>(string key, T value, int SiteId = 0, bool clearCache = true)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            key = key.Trim().ToLowerInvariant();
            string valueStr = CommonHelper.GetJNKJCustomTypeConverter(typeof(T)).ConvertToInvariantString(value);

            var allSettings = GetAllSettingsCached();
            var settingForCaching = allSettings.ContainsKey(key) ?
                allSettings[key].FirstOrDefault(x => x.SiteId == SiteId) : null;
            bool result = false;
            if (settingForCaching != null)
            {
                //update
                var setting = GetSettingById(settingForCaching.Id);
                setting.Value = valueStr;
                result = UpdateSetting(setting, clearCache);
            }
            else
            {
                //insert
                var setting = new Setting()
                {
                    Id = Guid.NewGuid(),
                    Name = key,
                    Value = valueStr,
                    SiteId = SiteId
                };
                result = InsertSetting(setting, clearCache);
            }

            return result;
        }

        /// <summary>
        /// Gets all settings
        /// </summary>
        /// <returns>Setting collection</returns>
        public virtual IList<Setting> GetAllSettings()
        {
            var query = from s in _settingRepository.Table
                        orderby s.Name, s.SiteId
                        select s;
            var settings = query.ToList();
            return settings;
        }

        /// <summary>
        /// Determines whether a setting exists
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="settings">Entity</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="SiteId">Store identifier</param>
        /// <returns>true -setting exists; false - does not exist</returns>
        public virtual bool SettingExists<T, TPropType>(T settings,
            Expression<Func<T, TPropType>> keySelector, int SiteId = 0)
            where T : ISettings, new()
        {
            var member = keySelector.Body as MemberExpression;
            if (member == null)
            {
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    keySelector));
            }

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException(string.Format(
                       "Expression '{0}' refers to a field, not a property.",
                       keySelector));
            }

            string key = typeof(T).Name + "." + propInfo.Name;

            string setting = GetSettingByKey<string>(key, SiteId: SiteId);
            return setting != null;
        }

        /// <summary>
        /// Load settings
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="SiteId">Store identifier for which settigns should be loaded</param>
        public virtual T LoadSetting<T>(int SiteId = 0) where T : ISettings, new()
        {
            var settings = Activator.CreateInstance<T>();

            foreach (var prop in typeof(T).GetProperties())
            {
                // get properties we can read and write to
                if (!prop.CanRead || !prop.CanWrite)
                    continue;

                var key = typeof(T).Name + "." + prop.Name;
                //load by store
                string setting = GetSettingByKey<string>(key, SiteId: SiteId, loadSharedValueIfNotFound: true);
                if (setting == null)
                    continue;

                if (!CommonHelper.GetJNKJCustomTypeConverter(prop.PropertyType).CanConvertFrom(typeof(string)))
                    continue;

                if (!CommonHelper.GetJNKJCustomTypeConverter(prop.PropertyType).IsValid(setting))
                    continue;

                object value = CommonHelper.GetJNKJCustomTypeConverter(prop.PropertyType).ConvertFromInvariantString(setting);

                //set property
                prop.SetValue(settings, value, null);
            }

            return settings;
        }

        /// <summary>
        /// Save settings object
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="SiteId">Store identifier</param>
        /// <param name="settings">Setting instance</param>
        public virtual bool SaveSetting<T>(T settings, int SiteId = 0) where T : ISettings, new()
        {
            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            bool result = true;
            try
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    // get properties we can read and write to
                    if (!prop.CanRead || !prop.CanWrite)
                        continue;

                    if (!CommonHelper.GetJNKJCustomTypeConverter(prop.PropertyType).CanConvertFrom(typeof(string)))
                        continue;

                    string key = typeof(T).Name + "." + prop.Name;
                    //Duck typing is not supported in C#. That's why we're using dynamic type
                    dynamic value = prop.GetValue(settings, null);
                    if (value != null)
                        SetSetting(key, value, SiteId, false);
                    else
                        SetSetting(key, "", SiteId, false);
                }

                //and now clear cache
                ClearCache();
            }
            catch (Exception ex)
            {
                //记录错误日志
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Save settings object
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="settings">Settings</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="SiteId">Store ID</param>
        /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
        public virtual bool SaveSetting<T, TPropType>(T settings,
            Expression<Func<T, TPropType>> keySelector,
            int SiteId = 0, bool clearCache = true) where T : ISettings, new()
        {

            bool result = true;
            try
            {
                var member = keySelector.Body as MemberExpression;
                if (member == null)
                {
                    throw new ArgumentException(string.Format(
                        "Expression '{0}' refers to a method, not a property.",
                        keySelector));
                }

                var propInfo = member.Member as PropertyInfo;
                if (propInfo == null)
                {
                    throw new ArgumentException(string.Format(
                           "Expression '{0}' refers to a field, not a property.",
                           keySelector));
                }

                string key = typeof(T).Name + "." + propInfo.Name;
                //Duck typing is not supported in C#. That's why we're using dynamic type
                dynamic value = propInfo.GetValue(settings, null);
                if (value != null)
                    SetSetting(key, value, SiteId, clearCache);
                else
                    SetSetting(key, "", SiteId, clearCache);
            }
            catch (Exception ex)
            {
                //记录错误日志
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Delete all settings
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        public virtual bool DeleteSetting<T>() where T : ISettings, new()
        {
            bool result = true;
            try
            {
                var settingsToDelete = new List<Setting>();
                var allSettings = GetAllSettings();
                foreach (var prop in typeof(T).GetProperties())
                {
                    string key = typeof(T).Name + "." + prop.Name;
                    settingsToDelete.AddRange(allSettings.Where(x => x.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase)));
                }

                foreach (var setting in settingsToDelete)
                    DeleteSetting(setting);
            }
            catch (Exception ex)
            {
                //记录错误日志
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Delete settings object
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="settings">Settings</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="SiteId">Store ID</param>
        public virtual bool DeleteSetting<T, TPropType>(T settings,
            Expression<Func<T, TPropType>> keySelector, int SiteId = 0) where T : ISettings, new()
        {
            bool result = true;
            try
            {
                var member = keySelector.Body as MemberExpression;
                if (member == null)
                {
                    throw new ArgumentException(string.Format(
                        "Expression '{0}' refers to a method, not a property.",
                        keySelector));
                }

                var propInfo = member.Member as PropertyInfo;
                if (propInfo == null)
                {
                    throw new ArgumentException(string.Format(
                           "Expression '{0}' refers to a field, not a property.",
                           keySelector));
                }

                string key = typeof(T).Name + "." + propInfo.Name;
                key = key.Trim().ToLowerInvariant();

                var allSettings = GetAllSettingsCached();
                var settingForCaching = allSettings.ContainsKey(key) ?
                    allSettings[key].FirstOrDefault(x => x.SiteId == SiteId) : null;
                if (settingForCaching != null)
                {
                    //update
                    var setting = GetSettingById(settingForCaching.Id);
                    DeleteSetting(setting);
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Clear cache
        /// </summary>
        public virtual void ClearCache()
        {
            _cacheManager.RemoveByPattern(SETTINGS_PATTERN_KEY);
        }

        #endregion
    }
}
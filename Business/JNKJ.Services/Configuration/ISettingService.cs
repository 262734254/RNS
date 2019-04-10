using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JNKJ.Domain;
using JNKJ.Domain.Configuration;

namespace JNKJ.Services.Configuration
{
    /// <summary>
    /// Setting service interface
    /// </summary>
    public partial interface ISettingService
    {
        /// <summary>
        /// Gets a setting by identifier
        /// </summary>
        /// <param name="settingId">Setting identifier</param>
        /// <returns>Setting</returns>
        Setting GetSettingById(Guid settingId);

        /// <summary>
        /// Deletes a setting
        /// </summary>
        /// <param name="setting">Setting</param>
        bool DeleteSetting(Setting setting);

        /// <summary>
        /// Get setting value by key
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="SiteId">Store identifier</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="loadSharedValueIfNotFound">A value indicating whether a shared (for all stores) value should be loaded if a value specific for a certain is not found</param>
        /// <returns>Setting value</returns>
        T GetSettingByKey<T>(string key, T defaultValue = default(T),
            int SiteId = 0, bool loadSharedValueIfNotFound = false);

        /// <summary>
        /// Set setting value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="SiteId">Store identifier</param>
        /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
        bool SetSetting<T>(string key, T value, int SiteId = 0, bool clearCache = true);

        /// <summary>
        /// Gets all settings
        /// </summary>
        /// <returns>Settings</returns>
        IList<Setting> GetAllSettings();

        /// <summary>
        /// Determines whether a setting exists
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="settings">Settings</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="SiteId">Store identifier</param>
        /// <returns>true -setting exists; false - does not exist</returns>
        bool SettingExists<T, TPropType>(T settings,
            Expression<Func<T, TPropType>> keySelector, int SiteId = 0)
            where T : ISettings, new();

        /// <summary>
        /// Load settings
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="SiteId">Store identifier for which settigns should be loaded</param>
        T LoadSetting<T>(int SiteId = 0) where T : ISettings, new();

        /// <summary>
        /// Save settings object
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="SiteId">Store identifier</param>
        /// <param name="settings">Setting instance</param>
        bool SaveSetting<T>(T settings, int SiteId = 0) where T : ISettings, new();

        /// <summary>
        /// Save settings object
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="settings">Settings</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="SiteId">Store ID</param>
        /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
        bool SaveSetting<T, TPropType>(T settings,
            Expression<Func<T, TPropType>> keySelector,
            int SiteId = 0, bool clearCache = true) where T : ISettings, new();

        /// <summary>
        /// Delete all settings
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        bool DeleteSetting<T>() where T : ISettings, new();

        /// <summary>
        /// Delete settings object
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="settings">Settings</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="SiteId">Store ID</param>
        bool DeleteSetting<T, TPropType>(T settings,
            Expression<Func<T, TPropType>> keySelector, int SiteId = 0) where T : ISettings, new();

        /// <summary>
        /// Clear cache
        /// </summary>
        void ClearCache();
    }
}

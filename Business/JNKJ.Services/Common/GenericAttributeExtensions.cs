using System;
using System.Linq;
using JNKJ.Core;
using JNKJ.Domain;
using JNKJ.Core.Infrastructure;
using JNKJ.Data;

namespace JNKJ.Services.Common
{
    public static class GenericAttributeExtensions
    {
        /// <summary>
        /// 获取一个实体属性
        /// </summary>
        /// <typeparam name="TPropType">属性类型</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="key">键</param>
        /// <param name="SiteId">站点ID，0加载全部</param>
        /// <returns>属性</returns>
        public static TPropType GetAttribute<TPropType>(this BaseEntity entity, string key, Guid SiteId)
        {
            var genericAttributeService = EngineContext.Current.Resolve<IGenericAttributeService>();
            return GetAttribute<TPropType>(entity, key, genericAttributeService, SiteId);
        }

        /// <summary>
        /// 获取实体的一个属性
        /// </summary>
        /// <typeparam name="TPropType">属性类型</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="key">关键字</param>
        /// <param name="genericAttributeService">属性生成操作类</param>
        /// <param name="SiteId">店铺ID，0代表所有</param>
        /// <returns>返回属性</returns>
        public static TPropType GetAttribute<TPropType>(this BaseEntity entity,
            string key, IGenericAttributeService genericAttributeService, Guid SiteId)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            string keyGroup = entity.GetUnproxiedEntityType().Name;

            var props = genericAttributeService.GetAttributesForEntity(entity.Id, keyGroup);
            //little hack here (only for unit testing). we should write ecpect-return rules in unit tests for such cases
            if (props == null)
                return default(TPropType);
            props = props.Where(x => x.SiteId == SiteId).ToList();
            if (props.Count == 0)
                return default(TPropType);

            var prop = props.FirstOrDefault(ga =>
                ga.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)); //should be culture invariant

            if (prop == null || string.IsNullOrEmpty(prop.Value))
                return default(TPropType);

            return CommonHelper.To<TPropType>(prop.Value);
        }
    }
}

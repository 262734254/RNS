using System;
using System.Collections.Generic;
using JNKJ.Domain;
using JNKJ.Domain.Common;

namespace JNKJ.Services.Common
{
    /// <summary>
    /// Generic attribute service interface
    /// </summary>
    public partial interface IGenericAttributeService
    {
        /// <summary>
        /// 删除一个属性
        /// </summary>
        /// <param name="attribute">属性实体</param>
        void DeleteAttribute(GenericAttribute attribute);

        /// <summary>
        /// 获取一个属性
        /// </summary>
        /// <param name="attributeId">属性ID</param>
        /// <returns>属性实体</returns>
        GenericAttribute GetAttributeById(Guid attributeId);

        /// <summary>
        /// 插入一条属性
        /// </summary>
        /// <param name="attribute">属性实体</param>
        void InsertAttribute(GenericAttribute attribute);

        /// <summary>
        /// Updates the attribute
        /// </summary>
        /// <param name="attribute">Attribute</param>
        void UpdateAttribute(GenericAttribute attribute);

        /// <summary>
        /// Get attributes
        /// </summary>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="keyGroup">Key group</param>
        /// <returns>Get attributes</returns>
        IList<GenericAttribute> GetAttributesForEntity(Guid entityId, string keyGroup);

        /// <summary>
        /// Save attribute value
        /// </summary>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="SiteId">Store identifier; pass 0 if this attribute will be available for all stores</param>
        void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value, Guid SiteId);
    }
}
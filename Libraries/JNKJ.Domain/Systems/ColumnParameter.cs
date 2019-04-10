using System;
using System.Collections.Generic;

namespace JNKJ.Domain.Systems
{
    public class ColumnParameter : BaseEntity
    {
        private ICollection<ColumnParameterValue> _parameterValue;
        /// <summary>
        /// 参数名
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// 参数的key值
        /// </summary>
        public string ParameterKey { get; set; }
        /// <summary>
        /// 对应具体的parameter的枚举
        /// </summary>
        public string ParameterType { get; set; }
        /// <summary>
        /// 对应具体的parameter的枚举,参数应用范围
        /// </summary>
        public string ParameterArea { get; set; }
        /// <summary>
        /// 是否允许修改参数的名称
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creater { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
        /// <summary>
        /// 最后一次更新的时间
        /// </summary>
        public DateTime? UpdateOnUtc { get; set; }
        /// <summary>
        /// 最后一次更新的用户
        /// </summary>
        public string Updater { get; set; }

        #region parameter properties
        /// <summary>
        ///获取或者设置参数对应的值列表
        /// </summary>
        public virtual ICollection<ColumnParameterValue> ParameterValueList
        {
            get { return _parameterValue ?? (_parameterValue = new List<ColumnParameterValue>()); }
            set { _parameterValue = value; }
        }

        #endregion
    }
}

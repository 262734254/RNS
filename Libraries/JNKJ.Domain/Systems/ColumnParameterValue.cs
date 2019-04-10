using System;

namespace JNKJ.Domain.Systems
{
    public class ColumnParameterValue : BaseEntity
    {
        /// <summary>
        /// 对应的ID
        /// </summary>
        public Guid ParameterId { get; set; }
        /// <summary>
        /// 显示的KEY值
        /// </summary>
        public string ParamKey { get; set; }
        /// <summary>
        /// 对应的value值
        /// </summary>
        public string ParamValue { get; set; }
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

        public ColumnParameter Parameters { get; set; }

        public bool IsChecked { get; set; }

    }
}

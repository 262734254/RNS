using System;
using JNKJ.Domain.Customers;

namespace JNKJ.Domain.Logging
{
    /// <summary>
    /// 活动日志
    /// </summary>
    public partial class ActivityLog : BaseEntity
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public Guid ActivityLogTypeId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 记录内容
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedOnUtc { get; set; }

        /// <summary>
        ///记录类型
        /// </summary>
        public virtual ActivityLogType ActivityLogType { get; set; }

        /// <summary>
        /// 关联的用户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}

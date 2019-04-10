using System;
using System.ComponentModel.DataAnnotations;
using JNKJ.Domain.Customers;
namespace JNKJ.Domain.Logging
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public partial class Log : BaseEntity
    {
        /// <summary>
        /// 日志级别
        /// </summary>
        public int LogLevelId { get; set; }

        /// <summary>
        /// 短消息
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// 完整消息
        /// </summary>
        public string FullMessage { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// 发生页面
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// 上级页面
        /// </summary>
        public string ReferrerUrl { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 日志级别
        /// </summary>
        public LogLevel LogLevel
        {
            get
            {
                return (LogLevel)this.LogLevelId;
            }
            set
            {
                this.LogLevelId = (int)value;
            }
        }

        /// <summary>
        /// 关联用户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}

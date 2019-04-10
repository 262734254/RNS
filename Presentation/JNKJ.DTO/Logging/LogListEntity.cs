using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Logging
{
    public  class LogListEntity
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        public Guid LogId { get; set; }
        /// <summary>
        /// 日志级别
        /// </summary>
        public int LogLevelId { get; set; }

        /// <summary>
        /// 短消息
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid? CustomerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 发生页面
        /// </summary>
        public string PageUrl { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}

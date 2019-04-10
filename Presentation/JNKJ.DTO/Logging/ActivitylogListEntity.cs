using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Logging
{
    public  class ActivitylogListEntity
    {
        public Guid LogId { get; set; }
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
        public virtual string ActivityLogType { get; set; }

    }
}

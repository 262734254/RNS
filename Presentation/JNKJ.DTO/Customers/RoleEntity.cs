using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Customers
{
    public class RoleEntity
    {
        /// <summary>
        /// 组ID
        /// </summary>
        public Guid roleId { get; set; }
        /// <summary>
        /// 组名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否系统默认组
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// 系统名
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedOnUtc { get; set; }

        /// <summary>
        /// 是否已经激活
        /// </summary>
        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Customers
{
    public class RolesListEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid RoleId { get; set; }
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

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 是否自动升级
        /// </summary>
        public bool IsUpgrade { get; set; }
        /// <summary>
        /// 组的级别
        /// </summary>
        public int Grade { get; set; }
        /// <summary>
        /// 升级所需点数
        /// </summary>
        public int UpgradePoint { get; set; }
        /// <summary>
        /// 组类型
        /// </summary>
        public string RoleType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using JNKJ.Domain.Customers;

namespace JNKJ.Domain.Security
{
    /// <summary>
    /// 权限记录
    /// </summary>
    public class PermissionRecord : BaseEntity
    {
        private ICollection<CustomerRole> _customerRoles;

        /// <summary>
        /// 权限名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 权限的系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 权限的所属类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string PermissionType { get; set; }
        /// <summary>
        /// 用户组
        /// </summary>
        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get { return _customerRoles ?? (_customerRoles = new List<CustomerRole>()); }
            protected set { _customerRoles = value; }
        }
    }
}

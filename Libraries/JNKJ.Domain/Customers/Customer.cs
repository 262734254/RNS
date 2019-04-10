using System;
using System.Collections.Generic;

namespace JNKJ.Domain.Customers
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    [Serializable]
    public partial class Customer : BaseEntity
    {
        private ICollection<CustomerRole> _customerRoles;

        /// <summary>
        /// 获取或设置一个用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 获取或设置一个邮箱地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telphone { get; set; }
        /// <summary>
        /// 获取或设置一个密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置一个密码加密格式ID
        /// </summary>
        public int PasswordFormatId { get; set; }

        /// <summary>
        /// 密码加密格式
        /// </summary>
        public PasswordFormat PasswordFormat
        {
            get { return (PasswordFormat)PasswordFormatId; }
            set { this.PasswordFormatId = (int)value; }
        }

        /// <summary>
        /// 获取或设置一个辅助加密字段
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 是否已经激活
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否是系统帐户
        /// </summary>
        public bool IsSystemAccount { get; set; }

        /// <summary>
        /// 用户系统名
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 最后一次登录IP
        /// </summary>
        public string LastIpAddress { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 最后一次登陆的纬度
        /// </summary>
        public decimal? LastLatitude { get; set; }

        /// <summary>
        /// 最后一次登陆的经度
        /// </summary>
        public decimal? LastLongitude { get; set; }

        /// <summary>
        ///最后一次登录时间
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// 最后活跃时间
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public string RegisterIp { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Point { get; set; }

        #region Navigation properties
        /// <summary>
        ///用户组
        /// </summary>
        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get { return _customerRoles ?? (_customerRoles = new List<CustomerRole>()); }
            set { _customerRoles = value; }
        }

        /// <summary>
        /// 用户默认属性
        /// </summary>
        public virtual CustomerAttribute CustomerAttribute
        {
            get;
            set;
        }
        /// <summary>
        /// 用户扩展配置
        /// </summary>
        public virtual CustomerExtentions CustomerExtentions { get; set; }
        #endregion
    }
}
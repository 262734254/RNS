using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Customers
{
    public class CustomerEntity
    {
        #region  Main
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
        /// 确认密码
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 获取或设置一个密码加密格式ID
        /// </summary>
        public int PasswordFormatId { get; set; }

        /// <summary>
        /// 获取或设置一个辅助加密字段
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 会员标识
        /// </summary>
        public Guid AffiliateId { get; set; }

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
        /// <summary>
        /// 所属工作组
        /// </summary>
        public Guid[] SelectedCustomerRoleIds { get; set; }
        #endregion

        #region Attribute
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string DateOfBirth { get; set; }
        /// <summary>
        /// 公司名
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyMobile { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyTelphone { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 获取或设置一个用户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 获取或者设置一个用户头像
        /// </summary>
        public string Avatar { get; set; }

        #endregion

        #region Extentions
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 是否是普通用户
        /// </summary>
        public bool IsCustomer { get; set; }
        /// <summary>
        /// 密保邮箱
        /// </summary>
        public string SecretEmail { get; set; }
        /// <summary>
        /// 密保电话
        /// </summary>
        public string SecretMobile { get; set; }
        /// <summary>
        /// 密码提示问题1
        /// </summary>
        public string Question1 { get; set; }
        /// <summary>
        /// 提示问题答案1
        /// </summary>
        public string Answer1 { get; set; }

        /// <summary>
        /// 密码提示问题1
        /// </summary>
        public string Question2 { get; set; }
        /// <summary>
        /// 提示问题答案1
        /// </summary>
        public string Answer2 { get; set; }
        /// <summary>
        /// 密码提示问题1
        /// </summary>
        public string Question3 { get; set; }
        /// <summary>
        /// 提示问题答案1
        /// </summary>
        public string Answer3 { get; set; }
        #endregion
    }
}

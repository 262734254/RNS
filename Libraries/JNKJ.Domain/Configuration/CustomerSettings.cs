using JNKJ.Domain.Customers;

namespace JNKJ.Domain.Configuration
{
    public class CustomerSettings : ISettings
    {
        /// <summary>
        /// 是否开放用户中心
        /// </summary>
        public bool AllowLogin { get; set; }
        /// <summary>
        /// 是否以用户名登陆
        /// </summary>
        public bool UsernamesEnabled { get; set; }
        /// <summary>
        ///  是否允许以手机号码或者用户名来登陆
        /// </summary>
        public bool MixLoginEnabled { get; set; }
        /// <summary>
        /// 是否允许用户更改用户名
        /// </summary>
        public bool AllowUsersToChangeUsernames { get; set; }

        /// <summary>
        /// 默认的密码加密格式
        /// </summary>
        public PasswordFormat DefaultPasswordFormat { get; set; }

        /// <summary>
        /// 嘻哈加密时，采用的加密算法（sh1或者md5)
        /// </summary>
        public string HashedPasswordFormat { get; set; }

        /// <summary>
        /// 用户注册方式
        /// </summary>
        public UserRegistrationType UserRegistrationType { get; set; }

        /// <summary>
        /// 用户验证方式
        /// </summary>
        public UserVerificationType UserVerificationType { get; set; }

        /// <summary>
        /// 是否允许用户更改头像
        /// </summary>
        public bool AllowCustomersToUploadAvatars { get; set; }

        /// <summary>
        /// 头像大小
        /// </summary>
        public int AvatarMaximumSizeBytes { get; set; }

        /// <summary>
        /// 是否必须上传头像
        /// </summary>
        public bool DefaultAvatarEnabled { get; set; }

        /// <summary>
        /// 新用户注册是否发送通知信息
        /// </summary>
        public bool NotifyNewCustomerRegistration { get; set; }

        /// <summary>
        /// 用户名显示
        /// </summary>
        public CustomerNameFormat CustomerNameFormat { get; set; }

        /// <summary>
        /// 删除后的用户，是否允许重新注册
        /// </summary>
        public bool SuffixDeletedCustomers { get; set; }

    }
}
using System;
using JNKJ.Dto.Enums;

namespace JNKJ.Dto.Customers
{
    [Serializable]
    public class AdminLoginRequest
    {
        /// <summary>
        /// 登陆名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 登陆密码
        /// 根据ValidateType类型，验证的是不同数据
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码，根据
        /// </summary>
        public string ValidateCode { get; set; }
        /// <summary>
        /// 是否记住密码
        /// </summary>
        public bool RememberMe { get; set; }

        public string RedirectUrl { get; set; }
        /// <summary>
        /// 验证模式
        /// </summary>
        public ValidateType ValidateMethod { get; set; }

    }
}

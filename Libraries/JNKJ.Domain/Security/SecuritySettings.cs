using System.Collections.Generic;
namespace JNKJ.Domain.Security
{
    public class SecuritySettings : ISettings
    {
        /// <summary>
        /// 验证方式（ＳＳＬ）
        /// </summary>
        public bool ForceSslForAllPages { get; set; }

        /// <summary>
        /// 加密键值
        /// </summary>
        public string EncryptionKey { get; set; }

        /// <summary>
        /// 后台管理的ＩＰ地址限制（只允许出现的ＩＰ）
        /// </summary>
        public List<string> AdminAreaAllowedIpAddresses { get; set; }
    }
}
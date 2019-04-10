using System;

namespace JNKJ.Domain.Customers
{
    public enum UserVerificationType : int
    {
        /// <summary>
        /// 无验证
        /// </summary>
        NoVerification = 0,
        /// <summary>
        /// 邮箱认证
        /// </summary>
        Verification = 10,
        /// <summary>
        /// 人工审核
        /// </summary>
        ArtificialAudit = 30
    }
}

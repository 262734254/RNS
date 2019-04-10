using JNKJ.Domain.Common;

namespace JNKJ.Services
{
    public enum StatusTypes
    {
        /// <summary>
        /// 正常的
        /// </summary>
        Normal = ConstKeys.NORMAL,
        /// <summary>
        /// 被删除的
        /// </summary>
        Deleted = ConstKeys.DELETED,
        /// <summary>
        /// 无效的
        /// </summary>
        Invalid = ConstKeys.INVALID,
        /// <summary>
        /// 审核中的
        /// </summary>
        Auditing = ConstKeys.AUDITING,
        /// <summary>
        /// 被拒绝
        /// </summary>
        Beny = ConstKeys.BENY
    }
}

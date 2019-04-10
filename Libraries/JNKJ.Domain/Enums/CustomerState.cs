using EraNet.Domain.Common;

namespace EraNet.Domain.Enums
{
    public enum CustomerState
    {
        /// <summary>
        /// 新增
        /// </summary>
        New = ConstantInfo.NEWLY,
        /// <summary>
        /// 正常
        /// </summary>
        Normal = ConstantInfo.NORMAL,
        /// <summary>
        /// 审核中
        /// </summary>
        Auditing = ConstantInfo.AUDITING,
        /// <summary>
        /// 隐藏
        /// </summary>
        Hidden = ConstantInfo.HIDDEN,
        /// <summary>
        /// 被锁定
        /// </summary>
        Lock = ConstantInfo.LOCKED,
        /// <summary>
        /// 被拒绝
        /// </summary>
        Beny = ConstantInfo.BENY,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = ConstantInfo.DELETED
    }
}

namespace JNKJ.Domain.Customers
{
    /// <summary>
    /// 注册方式
    /// </summary>
    public enum UserRegistrationType : int
    {
        /// <summary>
        /// 普通注册（用户名）
        /// </summary>
        Standard = 1,
        /// <summary>
        /// 邮箱注册
        /// </summary>
        Email = 2,
        /// <summary>
        /// 管理员添加
        /// </summary>
        AdminApproval = 3,
        /// <summary>
        /// 手机注册
        /// </summary>
        Mobile = 4,
        /// <summary>
        /// 不允许注册
        /// </summary>
        Disabled = 0
    }
}

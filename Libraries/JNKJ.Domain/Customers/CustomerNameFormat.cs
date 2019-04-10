namespace JNKJ.Domain.Customers
{
    /// <summary>
    /// 用户名格式
    /// </summary>
    public enum CustomerNameFormat : int
    {
        /// <summary>
        /// 显示邮箱
        /// </summary>
        ShowEmails = 1,
        /// <summary>
        /// 显示用户名
        /// </summary>
        ShowUsernames = 2,
        /// <summary>
        /// 显示全名
        /// </summary>
        ShowFullNames = 3,
        /// <summary>
        /// 显示简称
        /// </summary>
        ShowFirstName = 10
    }
}

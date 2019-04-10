using JNKJ.Domain.Customers;

namespace JNKJ.Core
{
    /// <summary>
    /// 当前工作上下文
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// 获取当前的用户
        /// </summary>
        Customer CurrentCustomer { get; set; }
        /// <summary>
        /// 获取或设置原始客户(模仿当前用户)
        /// </summary>
        Customer OriginalCustomerIfImpersonated { get; }
        /// <summary>
        ///是否是管理员
        /// </summary>
        bool IsAdmin { get; set; }
    }
}

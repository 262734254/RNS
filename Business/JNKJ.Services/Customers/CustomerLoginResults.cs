using JNKJ.Domain.Common;

namespace JNKJ.Services.Customers
{
    /// <summary>
    /// 登录返回的结果
    /// </summary>
    public enum CustomerLoginResults : int
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        Successful =ConstKeys.LOGIN_SUCCESSFUL,
        /// <summary>
        /// 用户不存在
        /// </summary>
        CustomerNotExist = ConstKeys.LOGIN_NOTEXIST,
        /// <summary>
        /// 密码错误
        /// </summary>
        WrongPassword = ConstKeys.LOGIN_WRONGPASSWORD,
        /// <summary>
        /// 用户未激活
        /// </summary>
        NotActive = ConstKeys.LOGIN_NOTACTIVE,
        /// <summary>
        /// 用户已经删除
        /// </summary>
        Deleted = ConstKeys.LOGIN_DELETED
    }
}

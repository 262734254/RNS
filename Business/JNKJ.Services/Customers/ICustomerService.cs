using System;
using System.Collections.Generic;
using JNKJ.Domain;
using JNKJ.Domain.Common;
using JNKJ.Domain.Customers;

namespace JNKJ.Services.Customers
{
    /// <summary>
    /// Customer service interface
    /// </summary>
    public partial interface ICustomerService
    {
        #region Customers

        /// <summary>
        /// 判断用户名或者用户ID是否存在,优先判断用户名
        /// </summary>
        /// <param name="customername">用户名</param>
        /// <param name="customerId">用户ID</param>
        /// <returns></returns>
        bool Exist(string customername, Guid customerId);

        /// <summary>
        /// 按给出的条件获取全部用户
        /// </summary>
        /// <param name="createdFromUtc">创建时间 (UTC); 为空忽略</param>
        /// <param name="createdToUtc">创建时间（最大）; 为空忽略</param>
        /// <param name="affiliateId">会员标识</param>
        /// <param name="vendorId">供应商标识</param>
        /// <param name="customerRoleIds">一个客户角色标识符列表（至少一个）; 设置为Null或者列表为空忽略; </param>
        /// <param name="email">Email; 为空忽略</param>
        /// <param name="username">用户名; 为空忽略</param>
        /// <param name="firstName">用户的名字; 为空忽略</param>
        /// <param name="lastName">用户的姓; 为空忽略</param>
        /// <param name="dayOfBirth">出生日; 0 时忽略</param>
        /// <param name="monthOfBirth">出生的月份;  0 时忽略</param>
        /// <param name="company">公司名; 为空忽略</param>
        /// <param name="phone">电话; 为空忽略</param>
        /// <param name="zipPostalCode">邮编; 为空忽略</param>
        /// <param name="status">用户状态，为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>返回一个用户列表集合</returns>
        IPagedList<Customer> GetAllCustomers(DateTime? createdFromUtc,
            DateTime? createdToUtc, Guid[] customerRoleIds = null, string email = null, string username = null,
            string firstName = null, string lastName = null,
            int dayOfBirth = 0, int monthOfBirth = 0, int customerType = 0,
            string company = null, string phone = null, string zipPostalCode = null, int status = 0,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_PAGESIZE);

        /// <summary>
        /// 根据密码加密格式获取符合条件的用户列表 (包括被删除的用户)
        /// </summary>
        /// <param name="passwordFormat">密码格式</param>
        /// <returns>返回一个用户列表集合</returns>
        IList<Customer> GetAllCustomersByPasswordFormat(PasswordFormat passwordFormat);

        /// <summary>
        /// 获取在线的用户
        /// </summary>
        /// <param name="lastActivityFromUtc">用户最后激活时间</param>
        /// <param name="customerRoleIds">一个用来过滤符的用户组ID的列表; 设置为 null 或者列表为空时忽略; </param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>返回一个用户列表集合</returns>
        IPagedList<Customer> GetOnlineCustomers(DateTime lastActivityFromUtc,
            Guid[] customerRoleIds, int pageIndex, int pageSize);

        /// <summary>
        /// 删除一个用户实体
        /// </summary>
        /// <param name="customer">用户实体类</param>
        bool DeleteCustomer(Customer customer);

        /// <summary>
        /// 获取一个用户实体
        /// </summary>
        /// <param name="customerId">用户的标识ID</param>
        /// <returns>用户实体类</returns>
        Customer GetCustomerById(Guid customerId);

        /// <summary>
        /// 根据用户标识数组获取用户列表
        /// </summary>
        /// <param name="customerIds">用户标识的数组集</param>
        /// <returns>返回一个用户列表集合</returns>
        IList<Customer> GetCustomersByIds(Guid[] customerIds);

        /// <summary>
        /// 根据email地址获取用户信息
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>用户实体类</returns>
        Customer GetCustomerByEmail(string email);

        /// <summary>
        /// 根据手机号码地址获取用户信息
        /// </summary>
        /// <param name="mobile">手机号码</param>
        /// <returns>用户实体类</returns>
        Customer GetCustomerByMobile(string mobile);

        /// <summary>
        /// Get customer by system role
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Customer</returns>
        Customer GetCustomerBySystemName(string systemName);

        /// <summary>
        /// 根据用户名，获取用户信息
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Customer</returns>
        Customer GetCustomerByUsername(string username);

        /// <summary>
        /// 根据用户名或者手机号码，获取用户信息
        /// </summary>
        /// <param name="usernameOrmobile"></param>
        /// <returns></returns>
        Customer GetCustomer(string usernameOrmobile);
        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        bool InsertCustomer(Customer customer);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        bool UpdateCustomer(Customer customer);

        ///// <summary>
        ///// Delete guest customer records
        ///// </summary>
        ///// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        ///// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        ///// <param name="onlyWithoutShoppingCart">A value indicating whether to delete customers only without shopping cart</param>
        ///// <param name="maxNumberOfRecordsToDelete">Maximum number of customer records to delete</param>
        ///// <returns>Number of deleted customers</returns>
        //int DeleteGuestCustomers(DateTime? createdFromUtc,
        //    DateTime? createdToUtc, bool onlyWithoutShoppingCart,
        //    int maxNumberOfRecordsToDelete);

        /// <summary>
        /// 获取指定地址附近的用户
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="area">定位的地址信息</param>
        /// <param name="pageSize">获取的数据大小</param>
        /// <returns></returns>
        List<Customer> GetNearbyCustomer(Guid userid, AreaInfo area, int pageSize);
        #endregion

        #region Customer roles

        /// <summary>
        /// Delete a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        bool DeleteCustomerRole(CustomerRole customerRole);

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        /// <returns>Customer role</returns>
        CustomerRole GetCustomerRoleById(Guid customerRoleId);

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="systemName">Customer role system name</param>
        /// <returns>Customer role</returns>
        CustomerRole GetCustomerRoleBySystemName(string systemName);

        IList<CustomerRole> GetCustomerRoleByRoleType(string RoleType, bool showHidden);

        /// <summary>
        /// Gets all customer roles
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Customer role collection</returns>
        IList<CustomerRole> GetAllCustomerRoles(bool showHidden = false);

        /// <summary>
        /// 分页获取用户组信息
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="IsSystem"></param>
        /// <param name="Status"></param>
        /// <param name="IsDel"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IPagedList<CustomerRole> GetAllCustomerRoles(string roleName, bool? IsSystem, bool? IsActive, string RoleType,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE, bool showHidden = false);

        /// <summary>
        /// Inserts a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        bool InsertCustomerRole(CustomerRole customerRole);

        /// <summary>
        /// Updates the customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        bool UpdateCustomerRole(CustomerRole customerRole);

        #endregion

        #region Customer Attribute
        /// <summary>
        /// 删除一个会员的附加属性
        /// </summary>
        /// <param name="CustomerAttribute">Customer Attribute</param>
        bool DeleteCustomerAttribute(CustomerAttribute customerAttribute);

        /// <summary>
        /// 根据会员int获取会员的附加属性
        /// </summary>
        /// <param name="Customerint">Customer int</param>
        /// <returns>Customer Attribute</returns>
        CustomerAttribute GetCustomerAttributeById(Guid customerId);

        /// <summary>
        /// 添加会员的附加属性
        /// </summary>
        /// <param name="CustomerAttribute">Customer Attribute</param>
        bool InsertCustomerAttribute(CustomerAttribute customerAttribute);

        /// <summary>
        ///更新会员的附加属性
        /// </summary>
        /// <param name="CustomerAttribute">Customer Attribute</param>
        bool UpdateCustomerAttribute(CustomerAttribute customerAttribute);
        #endregion

        #region Customer Extentions
        /// <summary>
        /// 插入会员的扩展设置
        /// </summary>
        /// <param name="customerExtentions"></param>
        /// <returns></returns>
        bool InsertCustomerExtentions(CustomerExtentions customerExtentions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerint"></param>
        /// <returns></returns>
        CustomerExtentions GetCustomerExtentionsId(Guid customerId);
        /// <summary>
        /// 更改一个会员的扩展设置
        /// </summary>
        /// <param name="customerExtentions"></param>
        /// <returns></returns>
        bool UpdateCustomerExtentions(CustomerExtentions customerExtentions);
        #endregion
    }
}
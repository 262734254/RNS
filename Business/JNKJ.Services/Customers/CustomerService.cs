using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Data;
using System.Data.Entity;
using JNKJ.Core;
using JNKJ.Cache.Caching;
using JNKJ.Core.Data;
using JNKJ.Domain;
using JNKJ.Domain.Common;
using JNKJ.Domain.Customers;
using JNKJ.Domain.Configuration;

namespace JNKJ.Services.Customers
{
    /// <summary>
    /// Customer service
    /// </summary>
    public partial class CustomerService : ICustomerService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        private const string CUSTOMERROLES_ALL_KEY = "JNKJ.customerrole.all-{0}";
        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : system name
        /// </remarks>
        private const string CUSTOMERROLES_BY_SYSTEMNAME_KEY = "JNKJ.customerrole.systemname-{0}";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string CUSTOMERROLES_PATTERN_KEY = "JNKJ.customerrole.";

        #endregion

        #region Fields

        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerRole> _customerRoleRepository;
        private readonly IRepository<CustomerAttribute> _customerAttributeRepository;
        private readonly IRepository<CustomerExtentions> _customerExtentionsRepository;
        private readonly ICacheManager _cacheManager;
        private readonly CustomerSettings _customerSettings;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="customerRepository">Customer repository</param>
        /// <param name="customerRoleRepository">Customer role repository</param>
        /// <param name="eventPublisher">Event published</param>
        /// <param name="customerSettings">Customer settings</param>
        public CustomerService(ICacheManager cacheManager,
            IRepository<Customer> customerRepository,
            IRepository<CustomerRole> customerRoleRepository,
            IRepository<CustomerAttribute> customerAttributeRepository,
            IRepository<CustomerExtentions> customerExtentionsRepository,
            CustomerSettings customerSettings)
        {
            this._cacheManager = cacheManager;
            this._customerRepository = customerRepository;
            this._customerRoleRepository = customerRoleRepository;
            this._customerAttributeRepository = customerAttributeRepository;
            this._customerExtentionsRepository = customerExtentionsRepository;
            this._customerSettings = customerSettings;
        }

        #endregion

        #region Methods

        #region Customers

        #region 判断用户是否存在
        /// <summary>
        /// 判断用户名或者用户ID是否存在,优先判断用户名
        /// </summary>
        /// <param name="customername">用户名</param>
        /// <param name="customerId">用户ID</param>
        /// <returns></returns>
        public bool Exist(string customername, Guid customerId)
        {
            if (string.IsNullOrEmpty(customername) && string.IsNullOrEmpty(customerId.ToString()))
                throw new ArgumentNullException("param is empty");
            var query = _customerRepository.Table;
            if (!string.IsNullOrEmpty(customername))
            {
                query = query.Where(c => c.Username == customername);
            }
            else
            {
                query = query.Where(c => c.Id == customerId);
            }
            return query.Count() > 0 ? true : false;

        }
        #endregion

        #region 按条件查询用户列表
        /// <summary>
        /// 按条件查询用户列表
        /// </summary>
        /// <param name="createdFromUtc">创建时间 (UTC); 为空忽略</param>
        /// <param name="createdToUtc">创建时间（最大）; 为空忽略</param>
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
        public virtual IPagedList<Customer> GetAllCustomers(DateTime? createdFromUtc,
            DateTime? createdToUtc, Guid[] customerRoleIds = null, string email = null, string username = null,
            string firstName = null, string lastName = null,
            int dayOfBirth = 0, int monthOfBirth = 0, int customerType = 0,
            string company = null, string phone = null, string zipPostalCode = null, int status = 0,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_PAGESIZE)
        {

            #region 判断值
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            #endregion

            var query = _customerRepository.Table;
            if (createdFromUtc.HasValue)
                query = query.Where(c => createdFromUtc.Value <= c.CreatedOnUtc);
            if (createdToUtc.HasValue)
                query = query.Where(c => createdToUtc.Value >= c.CreatedOnUtc);
            if (status > 0)
                query = query.Where(c => c.Status == status);
            if (customerRoleIds != null && customerRoleIds.Length > 0)
                query = query.Where(c => c.CustomerRoles.Select(cr => cr.Id).Intersect(customerRoleIds).Any());
            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(c => c.Email.Contains(email));
            if (!string.IsNullOrWhiteSpace(username))
                query = query.Where(c => c.Username.Contains(username));
            //search by phone
            if (!string.IsNullOrWhiteSpace(phone))
            {
                query = query.Where(c => c.Mobile.Contains(phone) || c.Telphone.Contains(phone));
            }
            if (customerType == 1)
            {
                query = query
                .Join(_customerExtentionsRepository.Table, x => x.Id, y => y.Id, (x, y) => new { Customer = x, Extention = y })
                .Where(z => z.Extention.IsAdmin == true)
                .Select(z => z.Customer);
            }
            else if (customerType == 2)
            {
                query = query
                        .Join(_customerExtentionsRepository.Table, x => x.Id, y => y.Id, (x, y) => new { Customer = x, Extention = y })
                        .Where(z => z.Extention.IsCustomer == true)
                        .Select(z => z.Customer);
            }
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query = query
                    .Join(_customerAttributeRepository.Table, x => x.Id, y => y.Id, (x, y) => new { Customer = x, Attribute = y })
                    .Where(z => z.Attribute.FirstName.Contains(firstName))
                    .Select(z => z.Customer);
            }
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query = query
                    .Join(_customerAttributeRepository.Table, x => x.Id, y => y.Id, (x, y) => new { Customer = x, Attribute = y })
                    .Where(z => z.Attribute.LastName.Contains(lastName))
                    .Select(z => z.Customer);
            }
            //date of birth is stored as a string into database.
            //we also know that date of birth is stored in the following format YYYY-MM-DD (for example, 1983-02-18).
            //so let's search it as a string
            if (dayOfBirth > 0 && monthOfBirth > 0)
            {
                //both are specified
                string dateOfBirthStr = monthOfBirth.ToString("00", CultureInfo.InvariantCulture) + "-" + dayOfBirth.ToString("00", CultureInfo.InvariantCulture);
                //EndsWith is not supported by SQL Server Compact
                //so let's use the following workaround http://social.msdn.microsoft.com/Forums/is/sqlce/thread/0f810be1-2132-4c59-b9ae-8f7013c0cc00

                //we also cannot use Length function in SQL Server Compact (not supported in this context)
                //z.Attribute.Value.Length - dateOfBirthStr.Length = 5
                //dateOfBirthStr.Length = 5
                query = query
                    .Join(_customerAttributeRepository.Table, x => x.Id, y => y.Id, (x, y) => new { Customer = x, Attribute = y })
                    .Where(z => z.Attribute.DateOfBirth.Substring(5, 5) == dateOfBirthStr)
                    .Select(z => z.Customer);
            }
            else if (dayOfBirth > 0)
            {
                //only day is specified
                string dateOfBirthStr = dayOfBirth.ToString("00", CultureInfo.InvariantCulture);
                //EndsWith is not supported by SQL Server Compact
                //so let's use the following workaround http://social.msdn.microsoft.com/Forums/is/sqlce/thread/0f810be1-2132-4c59-b9ae-8f7013c0cc00

                //we also cannot use Length function in SQL Server Compact (not supported in this context)
                //z.Attribute.Value.Length - dateOfBirthStr.Length = 8
                //dateOfBirthStr.Length = 2
                query = query
                    .Join(_customerAttributeRepository.Table, x => x.Id, y => y.Id, (x, y) => new { Customer = x, Attribute = y })
                    .Where(z => z.Attribute.DateOfBirth.Substring(8, 2) == dateOfBirthStr)
                    .Select(z => z.Customer);
            }
            else if (monthOfBirth > 0)
            {
                //only month is specified
                string dateOfBirthStr = "-" + monthOfBirth.ToString("00", CultureInfo.InvariantCulture) + "-";
                query = query
                    .Join(_customerAttributeRepository.Table, x => x.Id, y => y.Id, (x, y) => new { Customer = x, Attribute = y })
                    .Where(z => z.Attribute.DateOfBirth.Contains(dateOfBirthStr))
                    .Select(z => z.Customer);
            }
            //search by company
            if (!string.IsNullOrWhiteSpace(company))
            {
                query = query
                    .Join(_customerAttributeRepository.Table, x => x.Id, y => y.Id, (x, y) => new { Customer = x, Attribute = y })
                    .Where(z => z.Attribute.Company.Contains(company))
                    .Select(z => z.Customer);
            }


            query = query.OrderByDescending(c => c.CreatedOnUtc);

            var customers = new PagedList<Customer>(query, pageIndex, pageSize);
            return customers;
        }
        #endregion

        #region 根据用户密码格式获取用户列表
        /// <summary>
        /// Gets all customers by customer format (including deleted ones)
        /// </summary>
        /// <param name="passwordFormat">Password format</param>
        /// <returns>Customers</returns>
        public virtual IList<Customer> GetAllCustomersByPasswordFormat(PasswordFormat passwordFormat)
        {
            int passwordFormatId = (int)passwordFormat;

            var query = _customerRepository.Table;
            query = query.Where(c => c.PasswordFormatId == passwordFormatId);
            query = query.OrderByDescending(c => c.CreatedOnUtc);
            var customers = query.ToList();
            return customers;
        }
        #endregion

        #region 获取在线用户
        /// <summary>
        /// Gets online customers
        /// </summary>
        /// <param name="lastActivityFromUtc">Customer last activity date (from)</param>
        /// <param name="customerRoleIds">A list of customer role identifiers to filter by (at least one match); pass null or empty list in order to load all customers; </param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Customer collection</returns>
        public virtual IPagedList<Customer> GetOnlineCustomers(DateTime lastActivityFromUtc,
            Guid[] customerRoleIds, int pageIndex, int pageSize)
        {
            var query = _customerRepository.Table;
            query = query.Where(c => lastActivityFromUtc <= c.LastActivityDateUtc);
            query = query.Where(c => c.Status != (int)StatusTypes.Deleted);
            if (customerRoleIds != null && customerRoleIds.Length > 0)
                query = query.Where(c => c.CustomerRoles.Select(cr => cr.Id).Intersect(customerRoleIds).Any());

            query = query.OrderByDescending(c => c.LastActivityDateUtc);
            var customers = new PagedList<Customer>(query, pageIndex, pageSize);
            return customers;
        }
        #endregion

        #region 删除用户
        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual bool DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (customer.IsSystemAccount)
                throw new ExceptionExt(string.Format("System customer account ({0}) could not be deleted", customer.SystemName));

            customer.Status = (int)StatusTypes.Deleted;

            if (_customerSettings.SuffixDeletedCustomers)
            {
                if (!string.IsNullOrEmpty(customer.Email))
                    customer.Email += "-DELETED";
                if (!string.IsNullOrEmpty(customer.Username))
                    customer.Username += "-DELETED";
            }

            return UpdateCustomer(customer);
        }
        #endregion

        #region 根据用户ID获取用户
        /// <summary>
        /// 根据用户ID，获取用户
        /// </summary>
        /// <param name="customerId">用户ID</param>
        /// <returns>返回用户实体</returns>
        public virtual Customer GetCustomerById(Guid customerId)
        {
            if (string.IsNullOrEmpty(customerId.ToString()))
                return null;
            var customer = _customerRepository.GetById(customerId);

            return customer;
        }
        #endregion

        #region 根据用户ID数组获取用户列表
        /// <summary>
        /// 根据用户的ID数组，获取用户列表
        /// </summary>
        /// <param name="customerIds">用户ID数组</param>
        /// <returns>用户</returns>
        public virtual IList<Customer> GetCustomersByIds(Guid[] customerIds)
        {
            if (customerIds == null || customerIds.Length == 0)
                return new List<Customer>();

            var query = from c in _customerRepository.Table
                        where customerIds.Contains(c.Id)
                        select c;
            var customers = query.ToList();
            //sort by passed identifiers
            var sortedCustomers = new List<Customer>();
            foreach (Guid id in customerIds)
            {
                var customer = customers.Find(x => x.Id == id);
                if (customer != null)
                    sortedCustomers.Add(customer);
            }
            return sortedCustomers;
        }
        #endregion

        #region 根据EMAIL获取用户
        /// <summary>
        ///根据用户的EMAIL信息获取用户的实体信息
        /// </summary>
        /// <param name="email">Email地址</param>
        /// <returns>返回一个用户实体信息</returns>
        public virtual Customer GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var query = from c in _customerRepository.Table
                        orderby c.Id
                        where c.Email == email
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }
        #endregion

        #region 根据手机号码获取用户
        /// <summary>
        ///根据用户的手机信息获取用户的实体信息
        /// </summary>
        /// <param name="mobile">mobile号码</param>
        /// <returns>返回一个用户实体信息</returns>
        public virtual Customer GetCustomerByMobile(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
                return null;

            var query = from c in _customerRepository.Table
                        orderby c.Id
                        where c.Mobile == mobile
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }
        #endregion

        #region 根据系统名获取用户
        /// <summary>
        /// 根据系统名，获取一个用户实体
        /// </summary>
        /// <param name="systemName">系统名</param>
        /// <returns>用户实体</returns>
        public virtual Customer GetCustomerBySystemName(string systemName)
        {
            if (string.IsNullOrWhiteSpace(systemName))
                return null;

            var query = from c in _customerRepository.Table
                        orderby c.Id
                        where c.SystemName == systemName
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }
        #endregion

        #region 根据用户名获取用户
        /// <summary>
        /// 根据用户名获取用户实体
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>实体类</returns>
        public virtual Customer GetCustomerByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            var query = from c in _customerRepository.Table
                        orderby c.Id
                        where c.Username == username
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }
        #endregion

        #region 根据用户名或者手机号码获取用户
        /// <summary>
        /// 根据用户名或者手机号码，获取用户信息
        /// </summary>
        /// <param name="usernameOrmobile"></param>
        /// <returns></returns>
        public Customer GetCustomer(string usernameOrmobile)
        {
            if (string.IsNullOrWhiteSpace(usernameOrmobile))
                return null;

            var query = from c in _customerRepository.Table
                        orderby c.Id
                        where c.Mobile == usernameOrmobile || c.Username == usernameOrmobile
                        select c;
            var customer = query.FirstOrDefault();
            if (customer != null)
            {
                var entry = _customerRepository.Context.Entry<Customer>(customer);
                //加载
                entry.Collection(c => c.CustomerRoles).Load();
                foreach (var m in customer.CustomerRoles)
                {
                    var role = _customerRepository.Context.Entry<CustomerRole>(m);
                    role.Collection(c => c.PermissionRecords).Load();
                }
            }
            return customer;
        }
        #endregion

        #region  插入一条用户信息
        /// <summary>
        /// 插入一条用户信息
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual bool InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            bool result = _customerRepository.Insert(customer);

            return result;
        }
        #endregion

        #region 更新一个用户信息
        /// <summary>
        /// 更新一个用户信息
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual bool UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            bool result = _customerRepository.Update(customer);


            return result;
        }
        #endregion

        #region 获取用户周边的推荐用户
        public List<Customer> GetNearbyCustomer(Guid userid, AreaInfo area, int pageSize)
        {
            //如果指定的地址信息存在
            if (area == null)
            {
                var customer = GetCustomerById(userid);
                area = new AreaInfo();
                area.Latitude = customer.LastLatitude;
                area.Longitude = customer.LastLongitude;
            }
            var query = _customerRepository.Table.Where(c => c.LastLatitude > area.Latitude - 1);
            query = query.Where(c => c.LastLatitude < area.Latitude + 1);
            query = query.Where(c => c.LastLongitude > area.Longitude - 1);
            query = query.Where(c => c.LastLongitude < area.Longitude + 1);

            //query=query.OrderBy(c=>SqlFunctions. SqlFunctions.a())
            //                 order by abs(longitude -x)+abs(latitude -y) limit 100;
            //不存在的情况下，如果userid存在，那么获取该用户附近的
            return null;
        }
        #endregion
        #endregion

        #region 用户组

        /// <summary>
        /// 删除一个用户组
        /// </summary>
        /// <param name="customerRole">用户组</param>
        public virtual bool DeleteCustomerRole(CustomerRole customerRole)
        {
            if (customerRole == null)
                throw new ArgumentNullException("customerRole");

            if (customerRole.IsSystemRole)
                throw new ExceptionExt("System role could not be deleted");

            bool result = _customerRoleRepository.Delete(customerRole);

            _cacheManager.RemoveByPattern(CUSTOMERROLES_PATTERN_KEY);

            return result;
        }

        /// <summary>
        /// 获取一个用户组
        /// </summary>
        /// <param name="customerRoleId">用户组ID</param>
        /// <returns>返回实体</returns>
        public virtual CustomerRole GetCustomerRoleById(Guid customerRoleId)
        {
            if (string.IsNullOrEmpty(customerRoleId.ToString()))
                return null;

            return _customerRoleRepository.GetById(customerRoleId);
        }

        /// <summary>
        /// 获取一个用户组，根据名字
        /// </summary>
        /// <param name="systemName">Customer role system name</param>
        /// <returns>返回实体</returns>
        public virtual CustomerRole GetCustomerRoleBySystemName(string systemName)
        {
            if (string.IsNullOrWhiteSpace(systemName))
                return null;

            string key = string.Format(CUSTOMERROLES_BY_SYSTEMNAME_KEY, systemName);
            return _cacheManager.Get(key, () =>
            {
                var query = from cr in _customerRoleRepository.Table
                            orderby cr.Id
                            where cr.SystemName == systemName
                            select cr;
                var customerRole = query.FirstOrDefault();
                return customerRole;
            });
        }

        public virtual IList<CustomerRole> GetCustomerRoleByRoleType(string RoleType, bool showHidden)
        {
            if (string.IsNullOrWhiteSpace(RoleType))
                return null;

            string key = string.Format(CUSTOMERROLES_BY_SYSTEMNAME_KEY, RoleType);
            return _cacheManager.Get(key, () =>
            {
                var query = from cr in _customerRoleRepository.Table
                            orderby cr.Id
                            where cr.RoleType == RoleType
                            select cr;
                if (!showHidden) query = query.Where(c => c.Deleted == false);
                var customerRole = query.ToList();
                return customerRole;
            });
        }

        /// <summary>
        /// Gets all customer roles
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Customer role collection</returns>
        public virtual IList<CustomerRole> GetAllCustomerRoles(bool showHidden = false)
        {
            string key = string.Format(CUSTOMERROLES_ALL_KEY, showHidden);
            return _cacheManager.Get(key, () =>
            {
                var query = from cr in _customerRoleRepository.Table
                            orderby cr.Name
                            where (showHidden || cr.Active)
                            select cr;
                var customerRoles = query.ToList();
                return customerRoles;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="IsSystem"></param>
        /// <param name="Status"></param>
        /// <param name="IsDel"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual IPagedList<CustomerRole> GetAllCustomerRoles(string roleName, bool? IsSystem, bool? IsActive, string RoleType,
            int pageIndex = 0, int pageSize = 2147483647, bool showHidden = false)
        {
            var query = _customerRoleRepository.Table;
            if (!string.IsNullOrWhiteSpace(roleName)) query = query.Where(c => c.Name.Contains(roleName));
            if (IsSystem != null) query = query.Where(c => IsSystem.Value == c.IsSystemRole);
            if (IsActive != null) query = query.Where(c => IsActive == c.Active);
            if (!string.IsNullOrWhiteSpace(RoleType)) query = query.Where(c => RoleType == c.RoleType);
            if (!showHidden) query = query.Where(c => c.Deleted == false);
            query = query.OrderByDescending(c => c.CreatedOnUtc);
            var roles = new PagedList<CustomerRole>(query, pageIndex, pageSize);
            return roles;
        }

        /// <summary>
        /// Inserts a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public virtual bool InsertCustomerRole(CustomerRole customerRole)
        {
            if (customerRole == null)
                throw new ArgumentNullException("customerRole");

            bool result = _customerRoleRepository.Insert(customerRole);

            return result;
        }

        /// <summary>
        /// Updates the customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public virtual bool UpdateCustomerRole(CustomerRole customerRole)
        {
            if (customerRole == null)
                throw new ArgumentNullException("customerRole");

            bool result = _customerRoleRepository.Update(customerRole);

            _cacheManager.RemoveByPattern(CUSTOMERROLES_PATTERN_KEY);

            return result;
        }

        #endregion

        #region Customer Attribute
        /// <summary>
        /// 删除掉会员的扩展属性
        /// </summary>
        /// <param name="customerAttribute"></param>
        public bool DeleteCustomerAttribute(CustomerAttribute customerAttribute)
        {
            if (customerAttribute == null)
                throw new ArgumentNullException("customerAttribute");

            bool result = _customerAttributeRepository.Delete(customerAttribute);

            return result;
        }

        /// <summary>
        /// 根据int获取会员的扩展信息
        /// </summary>
        /// <param name="customerint"></param>
        /// <returns></returns>
        public CustomerAttribute GetCustomerAttributeById(Guid customerId)
        {
            if (string.IsNullOrEmpty(customerId.ToString()))
                return null;

            return _customerAttributeRepository.Table.Where(c => c.Id == customerId).FirstOrDefault();
        }

        /// <summary>
        /// 插入一个新的用户扩展信息
        /// </summary>
        /// <param name="customerAttribute"></param>
        public bool InsertCustomerAttribute(CustomerAttribute customerAttribute)
        {
            if (customerAttribute == null)
                throw new ArgumentNullException("customerAttribute");
            bool result = false;
            if (GetCustomerAttributeById(customerAttribute.Id) != null)
            {
                result = _customerAttributeRepository.Update(customerAttribute);
            }
            else
            {
                result = _customerAttributeRepository.Insert(customerAttribute);
            }

            return result;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="customerAttribute"></param>
        public bool UpdateCustomerAttribute(CustomerAttribute customerAttribute)
        {
            if (customerAttribute == null)
                throw new ArgumentNullException("customerAttribute");

            bool result = _customerAttributeRepository.Update(customerAttribute);

            return result;
        }
        #endregion

        #region Customer  Extentions

        public CustomerExtentions GetCustomerExtentionsId(Guid customerId)
        {
            if (string.IsNullOrEmpty(customerId.ToString()))
                return null;

            return _customerExtentionsRepository.Table.Where(c => c.Id == customerId).FirstOrDefault();
        }
        /// <summary>
        /// 插入会员的扩展设置
        /// </summary>
        /// <param name="customerExtentions"></param>
        /// <returns></returns>
        public bool InsertCustomerExtentions(CustomerExtentions customerExtentions)
        {
            if (customerExtentions == null)
                throw new ArgumentNullException("customerExtentions");
            bool result = false;
            if (GetCustomerExtentionsId(customerExtentions.Id) != null)
            {
                result = _customerExtentionsRepository.Update(customerExtentions);
            }
            else
            {
                result = _customerExtentionsRepository.Insert(customerExtentions);
            }

            return result;
        }

        public bool UpdateCustomerExtentions(CustomerExtentions customerExtentions)
        {
            if (customerExtentions == null)
                throw new ArgumentNullException("customer");

            bool result = _customerExtentionsRepository.Update(customerExtentions);

            return result;
        }
        #endregion
        #endregion
    }
}
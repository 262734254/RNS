using System.Web;
using JNKJ.Core;
using JNKJ.Domain.Customers;
using JNKJ.Core.Fakes;
using JNKJ.Services;
using JNKJ.Services.Customers;
using JNKJ.Services.Authentication;
using JNKJ.Services.Common;
namespace JNKJ.Web.Framework
{
    /// <summary>
    /// Work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        #region Fields

        private readonly HttpContextBase _httpContext;
        private readonly ICustomerService _customerService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IGenericAttributeService _genericAttributeService;

        private Customer _cachedCustomer;
        private Customer _originalCustomerIfImpersonated;

        #endregion

        #region Ctor

        public WebWorkContext(HttpContextBase httpContext,
            ICustomerService customerService,
            IAuthenticationService authenticationService,
            IGenericAttributeService genericAttributeService)
        {
            this._httpContext = httpContext;
            this._customerService = customerService;
            this._authenticationService = authenticationService;
            this._genericAttributeService = genericAttributeService;
        }

        #endregion

        #region Utilities

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        public virtual Customer CurrentCustomer
        {
            get
            {
                if (_cachedCustomer != null)
                    return _cachedCustomer;

                if (_httpContext == null || _httpContext is FakeHttpContext)
                {
                    //后台线程发起的请求
                    _cachedCustomer = _customerService.GetCustomerBySystemName("BackgroundTask");
                }

                //注册用户
                if (_cachedCustomer == null || _cachedCustomer.Status == (int)StatusTypes.Deleted || !_cachedCustomer.Active)
                {
                    _cachedCustomer = _authenticationService.GetAuthenticatedCustomer();
                }


                return _cachedCustomer;
            }
            set
            {
                _cachedCustomer = value;
            }
        }

        /// <summary>
        ///获取或设置原始客户  (如果当前的用户信息是假的)
        /// </summary>
        public virtual Customer OriginalCustomerIfImpersonated
        {
            get
            {
                return _originalCustomerIfImpersonated;
            }
        }

        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        public virtual bool IsAdmin { get; set; }

        #endregion
    }
}

using System;
using System.Linq;
using JNKJ.Core;
using JNKJ.Domain.Customers;
using JNKJ.Domain.Configuration;
using JNKJ.Services.Security;
using JNKJ.Common.Utility;
namespace JNKJ.Services.Customers
{
    /// <summary>
    /// Customer registration service
    /// </summary>
    public partial class CustomerRegistrationService : ICustomerRegistrationService
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IEncryptionService _encryptionService;
        private readonly CustomerSettings _customerSettings;
        private readonly RewardPointsSettings _rewardPointsSettings;
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="customerService">Customer service</param>
        /// <param name="encryptionService">Encryption service</param>
        /// <param name="newsLetterSubscriptionService">Newsletter subscription service</param>
        /// <param name="localizationService">Localization service</param>
        /// <param name="storeService">Store service</param>
        /// <param name="rewardPointsSettings">Reward points settings</param>
        /// <param name="customerSettings">Customer settings</param>
        public CustomerRegistrationService(ICustomerService customerService,
             IEncryptionService encryptionService,
            CustomerSettings customerSettings,
            RewardPointsSettings rewardPointsSettings)
        {
            this._customerService = customerService;
            this._encryptionService = encryptionService;
            this._customerSettings = customerSettings;
            this._rewardPointsSettings = rewardPointsSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 检查用户
        /// </summary>
        /// <param name="usernameOrEmail">用户名（用户名，邮箱，电话）</param>
        /// <param name="password">密码（密码，短信验证码）</param>
        /// <returns>Result</returns>
        public virtual CustomerLoginResults ValidateCustomer(string usernameOrMobile, string password)
        {
            Customer customer = _customerService.GetCustomer(usernameOrMobile);

            if (customer == null)
                return CustomerLoginResults.CustomerNotExist;
            if (customer.Status == (int)StatusTypes.Deleted)
                return CustomerLoginResults.Deleted;
            if (!customer.Active)
                return CustomerLoginResults.NotActive;

            string pwd = "";
            switch (customer.PasswordFormat)
            {
                case PasswordFormat.Encrypted:
                    pwd = _encryptionService.EncryptText(password);
                    break;
                case PasswordFormat.Hashed:
                    pwd = _encryptionService.CreatePasswordHash(password, customer.PasswordSalt, _customerSettings.HashedPasswordFormat);
                    break;
                default:
                    pwd = UtilityHelper.TxtEnDes(password);
                    break;
            }

            bool isValid = pwd == customer.Password;

            //save last login date
            if (isValid)
            {
                customer.LastLoginDateUtc = DateTime.UtcNow;
                _customerService.UpdateCustomer(customer);
                return CustomerLoginResults.Successful;
            }
            else
                return CustomerLoginResults.WrongPassword;
        }


        /// <summary>
        /// Register customer
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual CustomerRegistrationResult RegisterCustomer(Customer request)
        {
            var result = new CustomerRegistrationResult();
            #region 验证
            if (request == null)
                throw new ArgumentNullException("request");
            if (string.IsNullOrWhiteSpace(request.Username))
                throw new ArgumentNullException("Customer's name cant't Empty!");
            if (string.IsNullOrWhiteSpace(request.Password))
                throw new ArgumentNullException("Customer's password cant't Empty!");

            if (!Validator.IsUserName(request.Username))
            {
                result.AddError("Messages_Account.RegisterCustomer.Errors.UsernameError");
                return result;
            }
            if (_customerService.GetCustomerByUsername(request.Username) != null)
            {
                result.AddError("Messages_Account.RegisterCustomer.Errors.UsernameAlreadyExists");
                return result;
            }
            if (!Validator.IsPassword(request.Password))
            {
                result.AddError("Messages_Account.RegisterCustomer.Errors.PasswordError");
                return result;
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                if (!Validator.IsValidEmail(request.Email))
                {
                    result.AddError("Messages_CheckEmailAvailability.EmailError");
                    return result;
                }
                if (_customerService.GetCustomerByEmail(request.Email) != null)
                {
                    result.AddError("Messages_Account.RegisterCustomer.Errors.EmailAlreadyExists");
                    return result;
                }

            }
            #endregion
            #region 密码
            switch (request.PasswordFormat)
            {
                case PasswordFormat.Encrypted:
                    {
                        request.Password = _encryptionService.EncryptText(request.Password);
                        request.Password = UtilityHelper.MD5(request.Password);
                    }
                    break;
                case PasswordFormat.Hashed:
                    {
                        string saltKey = _encryptionService.CreateSaltKey(5);
                        request.PasswordSalt = saltKey;
                        request.Password = _encryptionService.CreatePasswordHash(request.Password, saltKey, _customerSettings.HashedPasswordFormat);
                        request.Password = UtilityHelper.MD5(request.Password);
                    }
                    break;
                //明码
                case PasswordFormat.Clear:
                default:
                    request.Password = UtilityHelper.TxtEnDes(request.Password);
                    break;
            }
            #endregion
            request.RegisterIp = UtilityHelper.GetRealIP();
            bool res = _customerService.InsertCustomer(request);
            //if (res)
            //{
            //    if (request.CustomerAttribute != null) _customerService.InsertCustomerAttribute(request.CustomerAttribute);
            //    if (request.CustomerExtentions != null) _customerService.InsertCustomerExtentions(request.CustomerExtentions);
            //}
            if (!res)
                result.AddError("Messages_Account.RegisterCustomer.Errors.RegisterFail");
            return result;

        }

        /// <summary>
        /// 修改基础信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual CustomerResult UpdateCustomer(Customer request)
        {
            var result = new CustomerResult();
            //传入了错误的参数
            if (request == null || string.IsNullOrEmpty(request.Id.ToString()))
                throw new ArgumentNullException("request");
            var model = _customerService.GetCustomerById(request.Id);
            //查不到指定的数据
            if (model == null)
                result.AddError("Account.CheckUser.NotExist");
            //只修改基础信息
            #region 
            #region 赋值
            model.Status = request.Status;
            model.Email = request.Email;
            model.Mobile = request.Mobile;
            model.SystemName = request.SystemName;
            model.UpdatedOnUtc = DateTime.UtcNow;
            if (model.CustomerAttribute == null) model.CustomerAttribute = new CustomerAttribute();
            model.CustomerAttribute.Id = model.Id;
            model.CustomerAttribute.Avatar = request.CustomerAttribute.Avatar;
            model.CustomerAttribute.Company = request.CustomerAttribute.Company;
            model.CustomerAttribute.CompanyAddress = request.CustomerAttribute.CompanyAddress;
            model.CustomerAttribute.DateOfBirth = request.CustomerAttribute.DateOfBirth;
            model.CustomerAttribute.FirstName = request.CustomerAttribute.FirstName;
            model.CustomerAttribute.Gender = request.CustomerAttribute.Gender;
            model.CustomerAttribute.LastName = request.CustomerAttribute.LastName;
            model.CustomerAttribute.CompanyMobile = request.CustomerAttribute.CompanyMobile;
            model.CustomerAttribute.NickName = request.CustomerAttribute.NickName;
            model.CustomerAttribute.CompanyTelphone = request.CustomerAttribute.CompanyTelphone;
            #endregion
            bool res = _customerService.UpdateCustomer(model);
            #endregion

            return null;
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual CustomerResult ChangePassword(ChangePasswordRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var result = new CustomerResult();
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                result.AddError("Account.ChangePassword.Errors.EmailIsNotProvided");
                return result;
            }
            if (string.IsNullOrWhiteSpace(request.NewPassword))
            {
                result.AddError("Account.ChangePassword.Errors.PasswordIsNotProvided");
                return result;
            }

            var customer = _customerService.GetCustomerByEmail(request.Email);
            if (customer == null)
            {
                result.AddError("Account.ChangePassword.Errors.EmailNotFound");
                return result;
            }


            var requestIsValid = false;
            if (request.ValidateRequest)
            {
                //password
                string oldPwd = "";
                switch (customer.PasswordFormat)
                {
                    case PasswordFormat.Encrypted:
                        oldPwd = _encryptionService.EncryptText(request.OldPassword);
                        oldPwd = UtilityHelper.MD5(oldPwd);
                        break;
                    case PasswordFormat.Hashed:
                        oldPwd = _encryptionService.CreatePasswordHash(request.OldPassword, customer.PasswordSalt, _customerSettings.HashedPasswordFormat);
                        oldPwd = UtilityHelper.MD5(oldPwd);
                        break;
                    case PasswordFormat.Clear:
                    default:
                        oldPwd = UtilityHelper.TxtEnDes(request.OldPassword);
                        break;
                }

                bool oldPasswordIsValid = oldPwd == customer.Password;
                if (!oldPasswordIsValid)
                    result.AddError("Account.ChangePassword.Errors.OldPasswordDoesntMatch");

                if (oldPasswordIsValid)
                    requestIsValid = true;
            }
            else
                requestIsValid = true;


            //at this point request is valid
            if (requestIsValid)
            {
                switch (request.NewPasswordFormat)
                {
                    case PasswordFormat.Encrypted:
                        {
                            customer.Password = _encryptionService.EncryptText(request.NewPassword);
                            customer.Password = UtilityHelper.MD5(customer.Password);
                        }
                        break;
                    case PasswordFormat.Hashed:
                        {
                            string saltKey = _encryptionService.CreateSaltKey(5);
                            customer.PasswordSalt = saltKey;
                            customer.Password = _encryptionService.CreatePasswordHash(request.NewPassword, saltKey, _customerSettings.HashedPasswordFormat);
                            customer.Password = UtilityHelper.MD5(customer.Password);
                        }
                        break;
                    case PasswordFormat.Clear:
                    default:
                        customer.Password = UtilityHelper.TxtEnDes(request.NewPassword);
                        break;
                }
                customer.PasswordFormat = request.NewPasswordFormat;
                _customerService.UpdateCustomer(customer);
            }

            return result;
        }

        /// <summary>
        /// Sets a user email
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newEmail">New email</param>
        public virtual void SetEmail(Customer customer, string newEmail)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            newEmail = newEmail.Trim();
            string oldEmail = customer.Email;

            if (!Validator.IsValidEmail(newEmail))
                throw new ExceptionExt("Account.EmailUsernameErrors.NewEmailIsNotValid");

            if (newEmail.Length > 100)
                throw new ExceptionExt("Account.EmailUsernameErrors.EmailTooLong");

            var customer2 = _customerService.GetCustomerByEmail(newEmail);
            if (customer2 != null && customer.Id != customer2.Id)
                throw new ExceptionExt("Account.EmailUsernameErrors.EmailAlreadyExists");

            customer.Email = newEmail;
            _customerService.UpdateCustomer(customer);

            //update newsletter subscription (if required)
        }

        /// <summary>
        /// Sets a customer username
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newUsername">New Username</param>
        public virtual void SetUsername(Customer customer, string newUsername)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (!_customerSettings.AllowUsersToChangeUsernames)
                throw new ExceptionExt("Changing usernames is not allowed");

            newUsername = newUsername.Trim();

            if (newUsername.Length > 100)
                throw new ExceptionExt("Account.EmailUsernameErrors.UsernameTooLong");

            var user2 = _customerService.GetCustomerByUsername(newUsername);
            if (user2 != null && customer.Id != user2.Id)
                throw new ExceptionExt("Account.EmailUsernameErrors.UsernameAlreadyExists") ;

            customer.Username = newUsername;
            _customerService.UpdateCustomer(customer);
        }

        #endregion
    }
}
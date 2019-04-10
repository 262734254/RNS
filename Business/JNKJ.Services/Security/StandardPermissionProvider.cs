using System.Collections.Generic;
using JNKJ.Domain.Customers;
using JNKJ.Domain.Security;

namespace JNKJ.Services.Security
{
    public partial class StandardPermissionProvider : IPermissionProvider
    {
        //admin area permissions
        public static readonly PermissionRecord AccessAdminPanel = new PermissionRecord { Name = "Access admin area", SystemName = "AccessAdminPanel", Category = "Standard", PermissionType="Administrator" };
        public static readonly PermissionRecord AllowCustomerImpersonation = new PermissionRecord { Name = "Admin area. Allow Customer Impersonation", SystemName = "AllowCustomerImpersonation", Category = "Customers" , PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageCatalog = new PermissionRecord { Name = "Admin area. Manage Catalog", SystemName = "ManageCatalog", Category = "Catalog", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageCustomers = new PermissionRecord { Name = "Admin area. Manage Customers", SystemName = "ManageCustomers", Category = "Customers", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageCustomerRoles = new PermissionRecord { Name = "Admin area. Manage Customer Roles", SystemName = "ManageCustomerRoles", Category = "Customers", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageOrders = new PermissionRecord { Name = "Admin area. Manage Orders", SystemName = "ManageOrders", Category = "Orders", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageGiftCards = new PermissionRecord { Name = "Admin area. Manage Gift Cards", SystemName = "ManageGiftCards", Category = "Orders", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageReturnRequests = new PermissionRecord { Name = "Admin area. Manage Return Requests", SystemName = "ManageReturnRequests", Category = "Orders", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageAffiliates = new PermissionRecord { Name = "Admin area. Manage Affiliates", SystemName = "ManageAffiliates", Category = "Promo", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageCampaigns = new PermissionRecord { Name = "Admin area. Manage Campaigns", SystemName = "ManageCampaigns", Category = "Promo", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageDiscounts = new PermissionRecord { Name = "Admin area. Manage Discounts", SystemName = "ManageDiscounts", Category = "Promo", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageNewsletterSubscribers = new PermissionRecord { Name = "Admin area. Manage Newsletter Subscribers", SystemName = "ManageNewsletterSubscribers", Category = "Promo", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManagePolls = new PermissionRecord { Name = "Admin area. Manage Polls", SystemName = "ManagePolls", Category = "Content Management", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageNews = new PermissionRecord { Name = "Admin area. Manage News", SystemName = "ManageNews", Category = "Content Management", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageBlog = new PermissionRecord { Name = "Admin area. Manage Blog", SystemName = "ManageBlog", Category = "Content Management", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageWidgets = new PermissionRecord { Name = "Admin area. Manage Widgets", SystemName = "ManageWidgets", Category = "Content Management", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageTopics = new PermissionRecord { Name = "Admin area. Manage Topics", SystemName = "ManageTopics", Category = "Content Management", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageForums = new PermissionRecord { Name = "Admin area. Manage Forums", SystemName = "ManageForums", Category = "Content Management", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageMessageTemplates = new PermissionRecord { Name = "Admin area. Manage Message Templates", SystemName = "ManageMessageTemplates", Category = "Content Management", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageCountries = new PermissionRecord { Name = "Admin area. Manage Countries", SystemName = "ManageCountries", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageLanguages = new PermissionRecord { Name = "Admin area. Manage Languages", SystemName = "ManageLanguages", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageSettings = new PermissionRecord { Name = "Admin area. Manage Settings", SystemName = "ManageSettings", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManagePaymentMethods = new PermissionRecord { Name = "Admin area. Manage Payment Methods", SystemName = "ManagePaymentMethods", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageExternalAuthenticationMethods = new PermissionRecord { Name = "Admin area. Manage External Authentication Methods", SystemName = "ManageExternalAuthenticationMethods", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageTaxSettings = new PermissionRecord { Name = "Admin area. Manage Tax Settings", SystemName = "ManageTaxSettings", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageShippingSettings = new PermissionRecord { Name = "Admin area. Manage Shipping Settings", SystemName = "ManageShippingSettings", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageCurrencies = new PermissionRecord { Name = "Admin area. Manage Currencies", SystemName = "ManageCurrencies", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageMeasures = new PermissionRecord { Name = "Admin area. Manage Measures", SystemName = "ManageMeasures", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageActivityLog = new PermissionRecord { Name = "Admin area. Manage Activity Log", SystemName = "ManageActivityLog", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageAcl = new PermissionRecord { Name = "Admin area. Manage ACL", SystemName = "ManageACL", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageEmailAccounts = new PermissionRecord { Name = "Admin area. Manage Email Accounts", SystemName = "ManageEmailAccounts", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManagePlugins = new PermissionRecord { Name = "Admin area. Manage Plugins", SystemName = "ManagePlugins", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageSystemLog = new PermissionRecord { Name = "Admin area. Manage System Log", SystemName = "ManageSystemLog", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageMessageQueue = new PermissionRecord { Name = "Admin area. Manage Message Queue", SystemName = "ManageMessageQueue", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord ManageMaintenance = new PermissionRecord { Name = "Admin area. Manage Maintenance", SystemName = "ManageMaintenance", Category = "Configuration", PermissionType = "Administrator" };
        public static readonly PermissionRecord UploadPictures = new PermissionRecord { Name = "Admin area. Upload Pictures", SystemName = "UploadPictures", Category = "Configuration", PermissionType = "Administrator" };

        public virtual IEnumerable<PermissionRecord> GetPermissions()
        {
            return new[]
            {
                AccessAdminPanel,
                AllowCustomerImpersonation,
                ManageCatalog,
                ManageCustomers,
                ManageCustomerRoles,
                ManageOrders,
                ManageGiftCards,
                ManageReturnRequests,
                ManageAffiliates,
                ManageCampaigns,
                ManageDiscounts,
                ManageNewsletterSubscribers,
                ManagePolls,
                ManageNews,
                ManageBlog,
                ManageWidgets,
                ManageTopics,
                ManageForums,
                ManageMessageTemplates,
                ManageCountries,
                ManageLanguages,
                ManageSettings,
                ManagePaymentMethods,
                ManageExternalAuthenticationMethods,
                ManageTaxSettings,
                ManageShippingSettings,
                ManageCurrencies,
                ManageMeasures,
                ManageActivityLog,
                ManageAcl,
                ManageEmailAccounts,
                ManagePlugins,
                ManageSystemLog,
                ManageMessageQueue,
                ManageMaintenance,
                UploadPictures
            };
        }

        public virtual IEnumerable<DefaultPermissionRecord> GetDefaultPermissions()
        {
            return new[]
            {
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = "Administrators",
                    PermissionRecords = new[]
                    {
                        AccessAdminPanel,
                        AllowCustomerImpersonation,
                        ManageCatalog,
                        ManageCustomers,
                        ManageCustomerRoles,
                        ManageOrders,
                        ManageGiftCards,
                        ManageReturnRequests,
                        ManageAffiliates,
                        ManageCampaigns,
                        ManageDiscounts,
                        ManageNewsletterSubscribers,
                        ManagePolls,
                        ManageNews,
                        ManageBlog,
                        ManageWidgets,
                        ManageTopics,
                        ManageForums,
                        ManageMessageTemplates,
                        ManageCountries,
                        ManageLanguages,
                        ManageSettings,
                        ManagePaymentMethods,
                        ManageExternalAuthenticationMethods,
                        ManageTaxSettings,
                        ManageShippingSettings,
                        ManageCurrencies,
                        ManageMeasures,
                        ManageActivityLog,
                        ManageAcl,
                        ManageEmailAccounts,
                        ManagePlugins,
                        ManageSystemLog,
                        ManageMessageQueue,
                        ManageMaintenance,
                        UploadPictures
                    }
                },
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using JNKJ.Core;
using JNKJ.Core.Data;
using JNKJ.Core.Fakes;
using JNKJ.Core.Infrastructure;
using JNKJ.Core.Infrastructure.DependencyManagement;
using JNKJ.Cache.Caching;
using JNKJ.Services.Logging;
using JNKJ.Services.Customers;
using JNKJ.Services.Configuration;
using JNKJ.Services.Authentication;
using JNKJ.Services.Security;
using JNKJ.Services.Common;
using JNKJ.Domain;
using JNKJ.Data;
using JNKJ.Services.RealNameSystem;
using JNKJ.Domain.RealNameSystem;
using JNKJ.Services.RealNameSystem.Realize;
using JNKJ.Services.Qiniu;

namespace JNKJ.Web.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();
            //WEB Helpers
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
            builder.RegisterApiControllers(typeFinder.GetAssemblies().ToArray());//注册api容器的实现

            //data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            builder.Register(x => new EfDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();

            builder.Register(x => (IEfDataProvider)x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();
            builder.Register(x => (IEfDataProvider)x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IEfDataProvider>().InstancePerDependency();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            if (dataProviderSettings != null && dataProviderSettings.IsValid())
            {
                var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.LoadSettings());
                var dataProvider = efDataProviderManager.LoadDataProvider();
                dataProvider.InitConnectionFactory();

                builder.Register<IDbContext>(c => new ObjectContextExt(dataProviderSettings.DataConnectionString)).InstancePerLifetimeScope();
            }
            else
            {
                builder.Register<IDbContext>(c => new ObjectContextExt(dataSettingsManager.LoadSettings().DataConnectionString)).InstancePerLifetimeScope();
            }


            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //cache manager
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("JNKJ_cache_static").SingleInstance();
            builder.RegisterType<PerRequestCacheManager>().As<ICacheManager>().Named<ICacheManager>("JNKJ_cache_per_request").InstancePerLifetimeScope();
            //work context

            builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();

            builder.RegisterType<GenericAttributeService>().As<IGenericAttributeService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerRegistrationService>().As<ICustomerRegistrationService>().InstancePerLifetimeScope();

            builder.RegisterType<SettingService>().As<ISettingService>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("JNKJ_cache_static"))
                .InstancePerLifetimeScope();
            builder.RegisterSource(new SettingsSource());
            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerLifetimeScope();
            builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();



            builder.RegisterType<DataDictionaryService>().As<IDataDictionary>().InstancePerLifetimeScope();            //数据字典
            builder.RegisterType<Company_EmployeService>().As<ICompany_Employe>().InstancePerLifetimeScope();            //企业信息--企业从业人员聘用关系
            builder.RegisterType<ContractFileService>().As<IContractFile>().InstancePerLifetimeScope();            //项目信息--合同附件表
            builder.RegisterType<Employee_MasterService>().As<IEmployee_Master>().InstancePerLifetimeScope();            //企业信息--从业人员基础信息
            builder.RegisterType<EntryExitHistoryService>().As<IEntryExitHistory>().InstancePerLifetimeScope();            //项目信息--进退场记录
            builder.RegisterType<PayRollService>().As<IPayRoll>().InstancePerLifetimeScope();                             //项目信息--工资单
            builder.RegisterType<PayRollDetailService>().As<IPayRollDetail>().InstancePerLifetimeScope();            //项目信息--工资明细
            builder.RegisterType<PersonalCertificationsService>().As<IPersonalCertifications>().InstancePerLifetimeScope();            //工人信息--人员资格证书信息
            builder.RegisterType<ProjectMasterService>().As<IProjectMaster>().InstancePerLifetimeScope();            //项目信息--项目基础信息
            builder.RegisterType<ProjectSubContractorService>().As<IProjectSubContractor>().InstancePerLifetimeScope();            //项目信息--项目参建单位信息
            builder.RegisterType<ProjectTrainingService>().As<IProjectTraining>().InstancePerLifetimeScope();            //项目信息--项目中的培训记录
            builder.RegisterType<ProjectWorkerService>().As<IProjectWorker>().InstancePerLifetimeScope();            //项目信息--项目中工人信息
            builder.RegisterType<SubContractorService>().As<ISubContractor>().InstancePerLifetimeScope();            //企业信息--企业信息
            builder.RegisterType<SubContractorBlackListService>().As<ISubContractorBlackList>().InstancePerLifetimeScope();            //企业信息--企业黑名单信息
            builder.RegisterType<SubContractorCertificationsService>().As<ISubContractorCertifications>().InstancePerLifetimeScope();            //企业信息--企业资质
            builder.RegisterType<TeamMasterService>().As<ITeamMaster>().InstancePerLifetimeScope();            //班组信息--班组基础信息
            builder.RegisterType<TeamMemberService>().As<ITeamMember>().InstancePerLifetimeScope();            //班组信息--班组成员
            builder.RegisterType<TeamReviewService>().As<ITeamReview>().InstancePerLifetimeScope();            //班组信息--班组评价
            builder.RegisterType<WorkerAttendanceService>().As<IWorkerAttendance>().InstancePerLifetimeScope();            //项目信息--刷卡数据
            builder.RegisterType<WorkerBadRecordsService>().As<IWorkerBadRecords>().InstancePerLifetimeScope();            //工人信息--工人不良行为记录信息
            builder.RegisterType<WorkerBlackListService>().As<IWorkerBlackList>().InstancePerLifetimeScope();            //工人信息--工人黑名单信息
            builder.RegisterType<WorkerContractRuleService>().As<IWorkerContractRule>().InstancePerLifetimeScope();            //项目信息--项目中工人劳动合同信息
            builder.RegisterType<WorkerGoodRecordsService>().As<IWorkerGoodRecords>().InstancePerLifetimeScope();            //工人信息--工人奖励记录信息
            builder.RegisterType<WorkerMasterService>().As<IWorkerMaster>().InstancePerLifetimeScope();            //工人信息--工人实名基础信息

            builder.RegisterType<QiniuService>().As<IQiniuService>().InstancePerLifetimeScope();            //七牛服务

            builder.RegisterType<UserService>().As<IUser>().InstancePerLifetimeScope();            //用户





            //pass MemoryCacheManager as cacheManager (cache settings between requests)
            builder.RegisterType<PermissionService>().As<IPermissionService>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("era_cache_static"))
                .InstancePerRequest();

            builder.RegisterType<CustomerActivityService>().As<ICustomerActivityService>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("era_cache_static"))
                .InstancePerLifetimeScope();

            //Register event consumers

            #region service register

            #endregion
        }

        public int Order
        {
            get { return 0; }
        }
    }


    public class SettingsSource : IRegistrationSource
    {
        static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
            "BuildRegistration",
            BindingFlags.Static | BindingFlags.NonPublic);

        public IEnumerable<IComponentRegistration> RegistrationsFor(
                Service service,
                Func<Service, IEnumerable<IComponentRegistration>> registrations)
        {
            var ts = service as TypedService;
            if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
            {
                var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                yield return (IComponentRegistration)buildMethod.Invoke(null, null);
            }
        }

        static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
        {
            try
            {
                return RegistrationBuilder
                    .ForDelegate((c, p) =>
                    {
                        //var currentsiteId = c.Resolve<ISiteContext>().CurrentSite.Id;
                        var currentsiteId = 1;
                        //uncomment the code below if you want load settings per site only when you have two sites installed.
                        //var currentsiteId = c.Resolve<IsiteService>().GetAllsites().Count > 1
                        //    c.Resolve<IsiteContext>().Currentsite.Id : 0;

                        //although it's better to connect to your database and execute the following SQL:
                        //DELETE FROM [Setting] WHERE [siteId] > 0
                        return c.Resolve<ISettingService>().LoadSetting<TSettings>(currentsiteId);
                    })
                    .InstancePerLifetimeScope()
                    .CreateRegistration();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IsAdapterForIndividualComponents { get { return false; } }
    }

}

using System.Web.Http;
using System.Web.Http.Cors;
using System.Configuration;

namespace JNKJ.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //跨域配置
            string allowedMethods = ConfigurationManager.AppSettings["allowedMethods"];
            string allowedOrigin = ConfigurationManager.AppSettings["allowedOrigin"];
            string allowedHeaders = ConfigurationManager.AppSettings["allowedHeaders"];
            var JNKJCors = new EnableCorsAttribute(allowedOrigin, allowedHeaders, allowedMethods)
            {
                SupportsCredentials = true
            };
            config.EnableCors(JNKJCors);

            //路由配置
            config.MapHttpAttributeRoutes();

            //Home/Index
            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "{controller}/{action}",
              defaults: new { controller = "Home", action = "Index", id = RouteParameter.Optional }
          );

            //api/RNS/WorkerMaster/getsystemlist
            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{area}/{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = RouteParameter.Optional }
            );

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}

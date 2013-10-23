using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

using log4net;
using GXP.Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace GXP
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Logon", id = UrlParameter.Optional } // 参数默认值
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // 默认情况下对 Entity Framework 使用 LocalDB
            //Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            string path = Server.MapPath("log4net.Config");
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(path));


            var dacontainer = new UnityContainer();
            UnityConfigurationSection daconfig = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            daconfig.Configure(dacontainer);
            CacheHelper.SetCacheItem("IOC", dacontainer, CacheItemPriority.NotRemovable);

            //var dacontainer = new UnityContainer();
            //UnityConfigurationSection daconfig = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //daconfig.Containers["DataAccess"].Configure(dacontainer);
            //CacheHelper.SetCacheItem("DAContainer", dacontainer, CacheItemPriority.NotRemovable);

            //var bizcontainer = new UnityContainer();
            //UnityConfigurationSection bizconfig = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //bizconfig.Containers["BizLogic"].Configure(bizcontainer);
            //CacheHelper.SetCacheItem("BizContainer", bizcontainer, CacheItemPriority.NotRemovable);
        }
    }
}
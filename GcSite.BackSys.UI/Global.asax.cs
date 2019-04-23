using GcSite.BackSys.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GcSite.BackSys.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //删除数据库重新创建数据库
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GcSiteDb>());
            //当models发生改变时修改数据库
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GcSiteDb, GcSite.BackSys.DAL.Migrations.Configuration>());
            //var dbMigrator = new DbMigrator(new GcSite.BackSys.DAL.Migrations.Configuration());
            //dbMigrator.Update();
        }
    }
}

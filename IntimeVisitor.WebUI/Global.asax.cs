using IntimeVisitor.Entities.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IntimeVisitor.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UpdateMigrations();
        }


        private void UpdateMigrations()
        {
            var _contex = new IntimeVisitorContext();
            var initializeMigrations = new MigrateDatabaseToLatestVersion<IntimeVisitorContext, Entities.Migrations.Configuration>();
            initializeMigrations.InitializeDatabase(_contex);
        }
    }
}

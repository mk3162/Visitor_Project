﻿using IntimeVisitor.Entities.Context;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;    
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IntimeVisitor.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
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

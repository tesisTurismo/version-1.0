﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AppTurs.Respaldo
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Data.Entity;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.LocalDataContext, Migrations.Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}

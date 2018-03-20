﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

#region Additional Namespaces
using AppSecurity.BLL;
using AppSecurity.DAL;
using AppSecurity.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
#endregion


namespace Jan2018DemoWebsite
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var RoleManager = new ApplicationRoleManager();
            RoleManager.AddDefaultRoles();

            var UserManager = new ApplicationUserManager(new
                   UserStore<ApplicationUser>(new ApplicationDbContext()));
            UserManager.AddDefaultUsers();

        }
    }
}
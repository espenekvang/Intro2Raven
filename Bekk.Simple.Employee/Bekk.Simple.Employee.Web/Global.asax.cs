﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bekk.Simple.Employee.App_Start;
using Raven.Client;
using Raven.Client.Document;

namespace Bekk.Simple.Employee
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class BekkSimpleEmployee : System.Web.HttpApplication
    {
        public static IDocumentStore DocumentStore { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeDocumentstore();
        }

        private static void InitializeDocumentstore()
        {
            DocumentStore = new DocumentStore{ConnectionStringName = "RavenDB"};
            DocumentStore.Initialize();
        }
    }
}
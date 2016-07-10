namespace UserSystem.Web
{
    using System;
    using System.Data.Entity;
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using UserSystem.Data;
    using UserSystem.Data.Migrations;
    using UserSystem.Web.Infrastructure.Mapping;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var autoMapperConfig = new AutoMapperConfig(Assembly.GetExecutingAssembly());
            autoMapperConfig.Execute();
        }
    }
}
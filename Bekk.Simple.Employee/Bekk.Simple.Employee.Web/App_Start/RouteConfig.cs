using System.Web.Mvc;
using System.Web.Routing;

namespace Bekk.Simple.Employee.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "EmployeeOverview", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
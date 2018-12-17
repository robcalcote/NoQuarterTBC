using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NoQuarterTBC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ADMIN ROUTE
            // URL/Admin will automatically take the user to Admin home page.
            routes.MapRoute(
                "Admin",
                "Admin/{controller}/{action}/{id}",
                new { controller = "AdminHome", action = "Index", id = UrlParameter.Optional }
            );

            // DEFAULT ROUTE
            // URL will automatically take the user to the Site Landing page.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

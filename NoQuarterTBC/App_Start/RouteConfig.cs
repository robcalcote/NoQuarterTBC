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

            // This route will be called if the user wants to navigate to the Admin page
            // Viewing all the scaffolded models for editing site information
            routes.MapRoute(
                "Admin",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Admin", action = "Index", id = "" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

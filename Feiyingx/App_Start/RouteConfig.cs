using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Feiyingx
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "projects",
                url: "projects",
                defaults: new { controller = "project", action = "index" }
            );
            routes.MapRoute(
                name: "projectDetail",
                url: "projects/{id}",
                defaults: new { controller = "project", action = "detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "text",
                url: "text",
                defaults: new { controller = "contact", action = "text" }
            );
            routes.MapRoute(
                name: "email",
                url: "email",
                defaults: new { controller = "contact", action = "email" }
            );
            routes.MapRoute(
                name: "admin",
                url: "admin",
                defaults: new { controller = "home", action = "admin" }
            );
            routes.MapRoute(
                name: "me",
                url: "me",
                defaults: new { controller = "account", action = "login" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
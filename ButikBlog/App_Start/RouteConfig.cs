using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ButikBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CategoryRoute",
                url: "c/{cid}/{slug}",
                defaults: new { controller = "Home", action = "Index", slug = UrlParameter.Optional },
                constraints: new { cid = "\\d+" }
            );

            routes.MapRoute(
                name: "PostRoute",
                url: "p/{id}/{slug}",
                defaults: new { controller = "Home", action = "ShowPost", slug = UrlParameter.Optional },
                constraints: new { id = "\\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               
             );

            routes.MapRoute(
               name: "ActionOnly",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "Index" }
           );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace asp.net_mvc_webapp
{   
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //convention based route + year / month specific value, @"{2015|2016}"
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate" },
            //    new { year = @"\d{4}", month = @"\d{2}"}
            //);

            //routes.MapMvcAttributeRoutes(
                
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

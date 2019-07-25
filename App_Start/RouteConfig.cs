using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Jarchim
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute("PostPaging1", "{controller}/{action}/{cat}/{page}/{title}",
defaults: new
{
 controller = "Page",
 action = "Ads",
 cat = "all",
 page = UrlParameter.Optional,
 title = UrlParameter.Optional
}
);
            routes.MapRoute("PostPaging2", "{controller}/{action}/{cat}/{page}/{title}",
defaults: new
{
controller = "Category",
action = "Ads",
cat= "all",
page = UrlParameter.Optional,
title = UrlParameter.Optional
}
);
        }
    }
}

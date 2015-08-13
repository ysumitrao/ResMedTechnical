﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StockTradingSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GetStockFiles",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "StockDetails", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "StockDetails", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

﻿using System.Web.Http;

namespace Zebra.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "panda/api/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
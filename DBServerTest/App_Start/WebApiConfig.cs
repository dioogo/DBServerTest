using DBServerTest.Infrastructure;
using DBServerTest.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DBServerTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            IUnityContainer container = new UnityContainer();


            registerServices(container);
            config.DependencyResolver = new IocResolver(container);
        }

        private static void registerServices(IUnityContainer container)
        {
            container.RegisterType<IRestaurantPollManager, RestaurantPollManager>();
        }
    }
}

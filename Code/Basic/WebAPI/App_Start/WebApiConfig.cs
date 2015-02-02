using System.Web.Http;

namespace WebApplication2
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
                defaults: new { id = RouteParameter.Optional },
				constraints: new { id = @"|\d+" }
            );

			config.Routes.MapHttpRoute(
				name: "LookupByName",
				routeTemplate: "api/{controller}/{name}",
				defaults: new { },
				constraints: new { name = @"[A-Za-z].*" }
			);
		}
    }
}

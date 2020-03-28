using System.Web.Http;
using ShoppingCart.Web.Filters;

namespace ShoppingCart.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {           
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ExceptionHandlerFilter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

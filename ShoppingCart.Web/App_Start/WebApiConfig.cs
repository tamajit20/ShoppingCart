using System.Web.Http;
using System.Web.Http.Cors;
using ShoppingCart.Web.Filters;

namespace ShoppingCart.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute("*", "Origin, Content-Type, Accept", "POST");
            config.EnableCors(cors);

            config.Filters.Add(new ExceptionHandlerFilter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

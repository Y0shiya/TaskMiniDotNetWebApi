using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskMiniBackend.Filters;

namespace TaskMiniBackend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API の設定およびサービス

            // Web API ルート
            config.MapHttpAttributeRoutes();

            if (config.Formatters.Contains(config.Formatters.XmlFormatter))
            {
                config.Formatters.Remove(config.Formatters.XmlFormatter);
            }
            if (!config.Formatters.Contains(config.Formatters.JsonFormatter))
            {
                config.Formatters.Add(config.Formatters.JsonFormatter);
            }

            //config.Filters.Add(new ArgumentExceptionFilterAttribute());
            //config.Filters.Add(new ArgumentExceptionFilterAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

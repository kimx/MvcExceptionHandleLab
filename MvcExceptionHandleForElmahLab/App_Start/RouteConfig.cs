using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcExceptionHandleForElmahLab
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RegisterElmah(routes);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
      

        }

        private static void RegisterElmah(RouteCollection routes)
        {
            var namespaces = new[] { "Elmah.Mvc" };

            var elmahRoute = "elmah";

            routes.MapRoute(
                "Elmah.Mvc",
                string.Format("{0}/{{resource}}", elmahRoute),
                new
                {
                    controller = "Elmah",
                    action = "Index",
                    resource = UrlParameter.Optional
                },
                null,
                namespaces);

            routes.MapRoute(
                "Elmah.Mvc.Detail",
                string.Format("{0}/detail/{{resource}}", elmahRoute),
                new
                {
                    controller = "Elmah",
                    action = "Detail",
                    resource = UrlParameter.Optional
                },
                null,
                namespaces);
        }
    }
}

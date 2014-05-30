using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcExceptionHandleForElmahLab.Controllers
{
    //http://beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html
    //此類別作廢因Elmah.mvc
    internal class ElmahResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            // try and get the resource from the {resource} part of the route
            var routeDataValues = context.RequestContext.RouteData.Values;
            var resource = routeDataValues["resource"];
            if (resource == null)
            {
                // alternatively, try the {action} 
                var action = routeDataValues["action"].ToString();
                // but only if it is elmah/Detail/{resource}
                if ("Detail".Equals(action, StringComparison.OrdinalIgnoreCase))
                    resource = action;
            }

            var httpContext = context.HttpContext;
            var request = httpContext.Request;
            var currentPath = request.Path;
            var queryString = request.QueryString;
            if (resource != null)
            {
                // make sure that ELMAH knows what the resource is
                var pathInfo = "." + resource;
                // also remove the resource from the path - else it will start chaining
                // e.g. /elmah/detail/detail/stylesheet
                var newPath = currentPath.Remove(currentPath.Length - pathInfo.Length);
                httpContext.RewritePath(newPath, pathInfo, queryString.ToString());
            }
            else
            {
                // we can't have paths such as elmah/ as the ELMAH handler will generate URIs such as elmah//stylesheet
                if (currentPath.EndsWith("/"))
                {
                    var newPath = currentPath.Remove(currentPath.Length - 1);
                    httpContext.RewritePath(newPath, null, queryString.ToString());
                }
            }

            var unwrappedHttpContext = httpContext.ApplicationInstance.Context;
            var handler = new ErrorLogPageFactory().GetHandler(unwrappedHttpContext, null, null, null);
            if (handler != null)
            {
                handler.ProcessRequest(unwrappedHttpContext);
            }
        }
    }
    public class ElmahController : Controller
    {
        // GET: Elmah
        public ActionResult Index(string resource)
        {
            /* Adapted by Alexander Beletsky */
            return new ElmahResult();
        }

        public ActionResult Detail(string resource)
        {
            /* Adapted by Alexander Beletsky */
            return new ElmahResult();
        }

    }
}
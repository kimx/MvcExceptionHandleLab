using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcExceptionHandleLab.Controllers
{
    //http://www.prideparrot.com/blog/archive/2012/5/exception_handling_in_asp_net_mvc#handleerror
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
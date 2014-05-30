using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcExceptionHandleLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeError()
        {
            using (Entities db = new Entities())
            {
                SYSCKIND ck = new SYSCKIND();
                ck.CKIND = "KIMX";
                db.SYSCKIND.Add(ck);
                db.SaveChanges();
                //db.SaveChangesAsync()
            }
            // throw new NotImplementedException("MakeError");
            return View();
        }
    }
}
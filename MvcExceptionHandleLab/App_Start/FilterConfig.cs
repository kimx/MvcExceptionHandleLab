using MvcExceptionHandleLab.Core;
using System.Web;
using System.Web.Mvc;

namespace MvcExceptionHandleLab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}

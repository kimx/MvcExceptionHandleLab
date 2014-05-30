using Elmah;
using MvcExceptionHandleForElmahLab.App_Start;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ElmahStartUp), "Start")]
namespace MvcExceptionHandleForElmahLab.App_Start
{
    public class ElmahStartUp
    {
        public static void Start()
        {
            HttpApplication.RegisterModule(typeof(ErrorLogModule));//透過程式記錄
            HttpApplication.RegisterModule(typeof(MyErrorMailModule));
            //   HttpApplication.RegisterModule(typeof(MyErrorFilterModule));

            Elmah.ServiceCenter.Current = ElmahServiceProviderQueryHandler;
            ErrorFilterConfiguration c = new ErrorFilterConfiguration();
        }

        private static IServiceProvider ElmahServiceProviderQueryHandler(object context)
        {
            var container = new ServiceContainer(context as IServiceProvider);
            var log = new XmlFileErrorLog(HttpContext.Current.Server.MapPath("~/KIM_ELAMH/"));
            log.ApplicationName = "SysCore";
            container.AddService(typeof(ErrorLog), log);

            // var mail=Elmah.m
            return container;

        }
    }
}
using Elmah;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MvcExceptionHandleForElmahLab.App_Start
{
    public class MyErrorLogModule : ErrorLogModule
    {
        protected override void OnError(object sender, EventArgs args)
        {
            base.OnError(sender, args);
        }
    }

    public class MyErrorMailModule : ErrorMailModule
    {

        protected override void OnInit(HttpApplication application)
        {
            this.Filtering += MyErrorMailModule_Filtering;
            base.OnInit(application);
        }

        void MyErrorMailModule_Filtering(object sender, ExceptionFilterEventArgs args)
        {
            var httpException = args.Exception.GetBaseException() as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
                args.Dismiss();
        }

        protected override object GetConfig()
        {
            //subject="Kim-ELMAH" from="kimxinfo@gmail.com" to="kimxinfo@gmail.com" useSsl="true" 
            Hashtable ht = new Hashtable();
            ht["subject"] = "ELMAH";
            ht["from"] = "kimxinfo@gmail.com";
            ht["to"] = "kimxinfo@gmail.com";
            ht["useSsl"] = "true";
            return ht;
        }




    }


}
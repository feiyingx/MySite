using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feiyingx.Data.Services;

namespace Feiyingx.Helpers
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            ExceptionService.HandleException(filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}
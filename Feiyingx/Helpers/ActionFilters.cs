using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feiyingx.Helpers
{
    public class AdminAuthenticationRequiredAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //If user is not authenticated, then redirect to 404
            bool isAuthenticated = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                UrlHelper helper = new UrlHelper(filterContext.RequestContext);
                filterContext.HttpContext.Response.Redirect(helper.Action("notfound", "error", new { area = "" }));
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
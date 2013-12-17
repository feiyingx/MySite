using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feiyingx.Helpers;

namespace Feiyingx.Controllers
{
    [CustomHandleError]
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult ServerError()
        {
            return View();
        }

        public ActionResult Problem()
        {
            return View();
        }

        /// <summary>
        /// For testing server error
        /// </summary>
        /// <returns></returns>
        public ActionResult Exception()
        {
            throw new NotImplementedException();
        }
    }
}

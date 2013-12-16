using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feiyingx.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Email()
        {
            return View();
        }

        public ActionResult Text()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }
    }
}

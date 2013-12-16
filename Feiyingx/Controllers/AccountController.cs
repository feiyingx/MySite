using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Feiyingx.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Simple login to authenticate
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String password)
        {
            if (password == "1qaz2wsx")
            {
                //If correct password, then continue, else do nothing
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie("feiyingx@gmail.com", true);
                Response.Cookies.Add(authCookie);
                
                return RedirectToAction("admin", "home");
            }
            return RedirectToAction("index", "home");
        }
    }
}

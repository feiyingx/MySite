using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feiyingx.Code.DataConstants;
using Feiyingx.Data.Services;
using Feiyingx.ViewModels;

namespace Feiyingx.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(SendEmailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String subject = String.Format("[Contact Email] From {0} {1} - {2}", vm.FirstName, vm.LastName, ((Enumerations.ContactReason)vm.Reason).ToString());
                    String body = String.Format(@"
Email: {0}
Message:
{1}", vm.Email, vm.Message);
                    EmailService.SendContactEmail(subject, body);
                    return Json(new { status = "success" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error" });
                }
                
            }
            //TODO: handle error if necessary
            return Json(new { status = "error" });
        }

        public ActionResult Text()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendText(SendTextViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String msg = String.Format("{0} {1} says: {2}", vm.FirstName, vm.LastName, vm.Message);
                    TwilioService.SendText(msg);
                    return Json(new { status = "success" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error" });
                }

            }
            //TODO: handle error if necessary
            return Json(new { status = "error" });
        }

        public ActionResult Video()
        {
            return View();
        }
    }
}

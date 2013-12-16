using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feiyingx.DataConstants;
using Feiyingx.Helpers;

namespace Feiyingx.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        [AdminAuthenticationRequired]
        public ActionResult Image(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                //Get file name from upload
                String fileName = Path.GetFileName(file.FileName);
                String path = Path.Combine(Server.MapPath(Constants.FinalUploadPath), fileName);
                file.SaveAs(path);

                //Build relative path for the file
                String relativePath = String.Format("{0}/{1}", Constants.FinalUploadPath.Replace("~", ""), fileName);
                return Json(new { status = "success", path = relativePath });
            }
            return Json(new { status = "error" });
        }
    }
}

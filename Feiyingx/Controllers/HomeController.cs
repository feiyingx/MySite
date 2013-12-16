using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feiyingx.Data.Models;
using Feiyingx.Data.Repos;
using Feiyingx.Helpers;

namespace Feiyingx.Controllers
{
    public class HomeController : Controller
    {
        private ProjectRepo projectRepo;

        public HomeController()
        {
            projectRepo = new ProjectRepo();
        }

        /// <summary>
        /// Get the featured projects and display it on homepage
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Project> featuredProjects = projectRepo.Featured();
            return View(featuredProjects);
        }

        [AdminAuthenticationRequired]
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

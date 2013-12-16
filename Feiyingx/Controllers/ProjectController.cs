using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feiyingx.Data.Models;
using Feiyingx.Data.Repos;
using Feiyingx.Helpers;
using Feiyingx.ViewModels;

namespace Feiyingx.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectRepo projectRepo;

        public ProjectController()
        {
            projectRepo = new ProjectRepo();
        }

        /// <summary>
        /// Action for the public facing 'Projects' section
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Project> projects = projectRepo.All();
            return View(projects);
        }

        /// <summary>
        /// Action to show the project detail page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            Project proj = projectRepo.Get(id);
            if (proj == null)
                return RedirectToAction("notfound", "error");

            return View(proj);
        }

        #region Admin actions
        //TODO: Add authentication check
        /// <summary>
        /// Action for loading the form to create a new project
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AdminAuthenticationRequired]
        public ActionResult New()
        {
            NewProjectViewModel vm = new NewProjectViewModel();
            return View(vm);
        }

        /// <summary>
        /// Action to save a new project into DB
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)] //This is needed to allow html chars to be posted thru the form
        [AdminAuthenticationRequired]
        public ActionResult New(NewProjectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //Map the viewmodel values to the DB model and then save it
                Project newProject = Mapper.From(vm);
                newProject = projectRepo.Create(newProject);
                return RedirectToAction("index");
            }
            return View(vm);
        }

        /// <summary>
        /// Action to load the edit view for a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AdminAuthenticationRequired]
        public ActionResult Edit(int id)
        {
            Project proj = projectRepo.Get(id);
            EditProjectViewModel vm = Mapper.ToEditProjectViewModel(proj);
            return View(vm);
        }

        /// <summary>
        /// Action to save the updates for a project
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)] //This is needed to allow html chars to be posted
        [AdminAuthenticationRequired]
        public ActionResult Edit(EditProjectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Project updatedProj = Mapper.From(vm);
                updatedProj = projectRepo.Update(updatedProj);
                return RedirectToAction("list");
            }
            return View(vm);
        }

        /// <summary>
        /// Action to list all the projects in the admin interface
        /// </summary>
        /// <returns></returns>
        [AdminAuthenticationRequired]
        public ActionResult List()
        {
            List<Project> projects = projectRepo.All();
            return View(projects);
        }
        #endregion
    }
}

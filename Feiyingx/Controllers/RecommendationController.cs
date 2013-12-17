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
    public class RecommendationController : Controller
    {
        private RecommendationRepo recRepo;

        public RecommendationController()
        {
            recRepo = new RecommendationRepo();
        }

        public ActionResult Index()
        {
            List<Recommendation> recs = recRepo.All();
            return View(recs);
        }

        #region Admin actions
        [HttpGet]
        [AdminAuthenticationRequired]
        public ActionResult New()
        {
            NewRecommendationViewModel vm = new NewRecommendationViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)] //This is needed to allow html chars to be posted thru the form
        [AdminAuthenticationRequired]
        public ActionResult New(NewRecommendationViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Recommendation rec = Mapper.From(vm);
                rec = recRepo.Create(rec);
                return RedirectToAction("list");
            }
            return View(vm);
        }

        [HttpGet]
        [AdminAuthenticationRequired]
        public ActionResult Edit(int id)
        {
            Recommendation rec = recRepo.Get(id);
            if (rec == null)
                return RedirectToAction("notfound", "error");
            EditRecommendationViewModel vm = Mapper.ToEditRecommendationViewModel(rec);
            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)] //This is needed to allow html chars to be posted thru the form
        [AdminAuthenticationRequired]
        public ActionResult Edit(EditRecommendationViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Recommendation rec = Mapper.From(vm);
                rec = recRepo.Update(rec);
                return RedirectToAction("list");
            }
            
            return View(vm);
        }

        [HttpGet]
        [AdminAuthenticationRequired]
        public ActionResult List()
        {
            List<Recommendation> recs = recRepo.All();
            return View(recs);
        }
        #endregion
    }
}

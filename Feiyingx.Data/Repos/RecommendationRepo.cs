using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feiyingx.Data.Models;

namespace Feiyingx.Data.Repos
{
    public class RecommendationRepo
    {
        private MySiteEntities context = new MySiteEntities();
        public Recommendation Get(int id)
        {
            if (id <= 0)
                return null;

            return context.Recommendations.FirstOrDefault(p => p.Id == id);
        }

        public Recommendation Create(Recommendation r)
        {
            if (r == null || r.Id != 0)
                return null;

            //Set the create/modify date to now
            r.DateCreated = DateTime.Now;
            r.DateModified = DateTime.Now;
            r = context.Recommendations.Add(r);
            context.SaveChanges();

            //Return newly created recommendation, which now contains the generated ID
            return r;
        }

        public Recommendation Update(Recommendation r)
        {
            if (r == null)
                return null;

            //Find the object in our DB
            Recommendation dbRecommendation = context.Recommendations.FirstOrDefault(rec => rec.Id == r.Id);
            if (dbRecommendation == null)
                return null;

            dbRecommendation.CompanyName = r.CompanyName;
            dbRecommendation.CompanyUrl = r.CompanyUrl;
            dbRecommendation.CssClass = r.CssClass;
            dbRecommendation.DateModified = DateTime.Now;
            dbRecommendation.FirstName = r.FirstName;
            dbRecommendation.LastName = r.LastName;
            dbRecommendation.LinkedIn = r.LinkedIn;
            dbRecommendation.PositionTitle = r.PositionTitle;
            dbRecommendation.Message = r.Message;
            dbRecommendation.RecommendationDate = r.RecommendationDate;

            context.SaveChanges();
            return dbRecommendation;
        }

        public void Delete(int id)
        {
            if (id <= 0)
                return;

            Recommendation rec = context.Recommendations.FirstOrDefault(r => r.Id == id);
            if (rec != null)
            {
                context.Recommendations.Remove(rec);
                context.SaveChanges();
            }
        }

        public List<Recommendation> All()
        {
            return context.Recommendations.OrderByDescending(r => r.RecommendationDate).ToList();
        }
    }
}

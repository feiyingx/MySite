using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feiyingx.Data.Models;

namespace Feiyingx.Data.Repos
{
    public class ProjectRepo
    {
        private MySiteEntities context = new MySiteEntities();
        public Project Get(int id)
        {
            if (id <= 0)
                return null;

            return context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public Project Create(Project p)
        {
            if (p == null || p.Id != 0)
                return null;

            //Set the create/modify date to now
            p.DateCreated = DateTime.Now;
            p.DateModified = DateTime.Now;
            p = context.Projects.Add(p);
            context.SaveChanges();

            //Return newly created p, which now contains the generated ID
            return p;
        }

        public Project Update(Project p)
        {
            if (p == null)
                return null;

            //Find the object in our DB
            Project dbProject = context.Projects.FirstOrDefault(proj => proj.Id == p.Id);
            if (dbProject == null)
                return null;

            dbProject.FeatureDescription = p.FeatureDescription;
            dbProject.FeatureMainImage = p.FeatureMainImage;
            dbProject.FeatureTitle = p.FeatureTitle;
            dbProject.IsFeatured = p.IsFeatured;
            dbProject.ProjectDate = p.ProjectDate;
            dbProject.ProjectDescription = p.ProjectDescription;
            dbProject.ProjectFeatures = p.ProjectFeatures;
            dbProject.ProjectMainImage = p.ProjectMainImage;
            dbProject.ProjectTech = p.ProjectTech;
            dbProject.ProjectTitle = p.ProjectTitle;
            dbProject.ProjectUrl = p.ProjectUrl;
            dbProject.ProjectUrlText = p.ProjectUrlText;
            dbProject.Type = p.Type;
            dbProject.FeatureCssTheme = p.FeatureCssTheme;
            dbProject.DateModified = DateTime.Now;

            context.SaveChanges();
            return dbProject;
        }

        public void Delete(int id)
        {
            if (id <= 0)
                return;

            Project proj = context.Projects.FirstOrDefault(p => p.Id == id);
            if (proj != null)
            {
                context.Projects.Remove(proj);
                context.SaveChanges();
            }
        }

        public List<Project> All()
        {
            return context.Projects.OrderByDescending(p => p.ProjectDate).ToList();
        }

        public List<Project> Featured()
        {
            return context.Projects.Where(p => p.IsFeatured).OrderByDescending(p => p.ProjectDate).ToList();
        }
    }
}

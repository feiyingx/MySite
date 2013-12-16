using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Feiyingx.Data.Models;
using Feiyingx.Code.DataConstants;

namespace Feiyingx.ViewModels
{
    public class Mapper
    {
        /// <summary>
        /// Maps a NewProjectViewModel to a new Project object
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public static Project From(NewProjectViewModel vm)
        {
            Project result = new Project();
            result.FeatureDescription = vm.FeatureDescription;
            result.FeatureMainImage = vm.FeatureMainImage;
            result.FeatureTitle = vm.FeatureTitle;
            result.IsFeatured = vm.IsFeatured;
            result.ProjectDate = vm.ProjectDate;
            result.ProjectDescription = vm.ProjectDescription;
            result.ProjectFeatures = vm.ProjectFeatures;
            result.ProjectMainImage = vm.ProjectMainImage;
            result.ProjectTech = vm.ProjectTech;
            result.ProjectTitle = vm.ProjectTitle;
            result.ProjectUrl = vm.ProjectUrl;
            result.ProjectUrlText = vm.ProjectUrlText;
            result.Type = (int)vm.Type;
            result.FeatureCssTheme = vm.FeaturedCssTheme;

            return result;
        }

        /// <summary>
        /// Maps a EditProjectViewModel to a new Project object
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public static Project From(EditProjectViewModel vm)
        {
            if (vm == null)
                return null;

            Project result = new Project();
            result.Id = vm.Id;
            result.FeatureDescription = vm.FeatureDescription;
            result.FeatureMainImage = vm.FeatureMainImage;
            result.FeatureTitle = vm.FeatureTitle;
            result.IsFeatured = vm.IsFeatured;
            result.ProjectDate = vm.ProjectDate;
            result.ProjectDescription = vm.ProjectDescription;
            result.ProjectFeatures = vm.ProjectFeatures;
            result.ProjectMainImage = vm.ProjectMainImage;
            result.ProjectTech = vm.ProjectTech;
            result.ProjectTitle = vm.ProjectTitle;
            result.ProjectUrl = vm.ProjectUrl;
            result.ProjectUrlText = vm.ProjectUrlText;
            result.Type = (int)vm.Type;
            result.FeatureCssTheme = vm.FeatureCssTheme;

            return result;
        }

        /// <summary>
        /// Maps a Project object to a new EditProjectViewModel object
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public static EditProjectViewModel ToEditProjectViewModel(Project proj)
        {
            if (proj == null) 
                return null;

            EditProjectViewModel result = new EditProjectViewModel();
            result.Id = proj.Id;
            result.FeatureDescription = proj.FeatureDescription;
            result.FeatureMainImage = proj.FeatureMainImage;
            result.FeatureTitle = proj.FeatureTitle;
            result.IsFeatured = proj.IsFeatured;
            result.ProjectDate = proj.ProjectDate.Value;
            result.ProjectDescription = proj.ProjectDescription;
            result.ProjectFeatures = proj.ProjectFeatures;
            result.ProjectMainImage = proj.ProjectMainImage;
            result.ProjectTech = proj.ProjectTech;
            result.ProjectTitle = proj.ProjectTitle;
            result.ProjectUrl = proj.ProjectUrl;
            result.ProjectUrlText = proj.ProjectUrlText;
            result.Type = (Enumerations.ProjectType)proj.Type;
            result.FeatureCssTheme = proj.FeatureCssTheme;

            return result;
        }
    }
}
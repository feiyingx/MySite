using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Feiyingx.DataConstants;

namespace Feiyingx.ViewModels
{
    public class EditProjectViewModel
    {
        public int Id { get; set; }
        public Enumerations.ProjectType Type { get; set; }
        public string ProjectMainImage { get; set; }
        [Required]
        public string ProjectTitle { get; set; }
        public DateTime ProjectDate { get; set; }
        [Required]
        public string ProjectDescription { get; set; }
        [Required]
        public string ProjectFeatures { get; set; }
        [Required]
        public string ProjectTech { get; set; }
        public string FeatureMainImage { get; set; }
        public string FeatureTitle { get; set; }
        public string FeatureDescription { get; set; }
        public string ProjectUrl { get; set; }
        public string ProjectUrlText { get; set; }
        public bool IsFeatured { get; set; }
        public string FeatureCssTheme { get; set; }
    }
}
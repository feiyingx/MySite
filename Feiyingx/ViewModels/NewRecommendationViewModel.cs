using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feiyingx.ViewModels
{
    public class NewRecommendationViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PositionTitle { get; set; }
        public string LinkedIn { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string CompanyUrl { get; set; }
        public string CssClass { get; set; }
        public System.DateTime RecommendationDate { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feiyingx.ViewModels
{
    public class SendTextViewModel
    {
        [MaxLength(5000)]
        public string FirstName { get; set; }
        [MaxLength(5000)]
        public string LastName { get; set; }
        [MaxLength(5000)]
        public string Message { get; set; }
    }
}
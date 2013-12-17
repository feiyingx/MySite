using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feiyingx.ViewModels
{
    public class SendEmailViewModel
    {
        [MaxLength(5000)]
        public string FirstName { get; set; }
        [MaxLength(5000)]
        public string LastName { get; set; }
        [MaxLength(5000)]
        public string Email { get; set; }
        public int Reason { get; set; }
        [MaxLength(5000)]
        public string Message { get; set; }
    }
}
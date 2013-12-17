using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Feiyingx.Code;

namespace Feiyingx.Data.Services
{
    public class ExceptionService
    {
        public static void HandleException(Exception ex)
        {
            string subject = String.Format("[{0}][Exception] - {1}", "Feiyingx Site", ex.Message);
            string innerExceptionMessage = ex.InnerException == null ? "" : ex.InnerException.Message;
            string body = String.Format(@"
{0}
URL========================================
{1}
STACK TRACE================================
{2}
INNER EXCEPTION============================
{3}
SOURCE============================
{4}

", ex.ToString(), HttpContext.Current.Request.RawUrl, ex.StackTrace, innerExceptionMessage, ex.Source);

            EmailService.SendEmail(Config.ExceptionSettings.ExceptionEmail(), subject, body);
        }
    }
}

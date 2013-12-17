using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Feiyingx.Code;

namespace Feiyingx.Data.Services
{
    public class EmailService
    {
        public static void SendContactEmail(string subject, string body)
        {
            SendEmail(Config.EmailSettings.ContactUsRecipient(), subject, body);
        }

        public static void SendEmail(string toAddress, string subject, string body)
        {
            SmtpClient smtp = null;
            string username = Config.EmailSettings.Username();
            if (Config.ApplicationSettings.Environment() == "local")
            {
                smtp = new SmtpClient("127.0.0.1", 25);
                smtp.UseDefaultCredentials = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            }
            else
            {
                smtp = new SmtpClient(Config.EmailSettings.HostName(), Config.EmailSettings.Port());
                smtp.Credentials = new NetworkCredential(username, Config.EmailSettings.Password());
            }
            MailAddress from = new MailAddress(username, "Ken Wang");
            MailAddress to = new MailAddress(toAddress);
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = subject;
            msg.Body = body;

            smtp.Send(msg);
        }
    }
}

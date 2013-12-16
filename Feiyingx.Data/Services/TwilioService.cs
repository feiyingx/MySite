using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feiyingx.Code;
using Twilio;

namespace Feiyingx.Data.Services
{
    public class TwilioService
    {
        public static void SendText(String message)
        {
            string AccountSid = Config.TwilioSettings.AccountId();
            string authToken = Config.TwilioSettings.AuthToken();
            TwilioRestClient twilio = new TwilioRestClient(AccountSid, authToken);
            var sentMessage = twilio.SendSmsMessage(Config.TwilioSettings.TwilioPhoneNumber(), "5628419855", message);
            //sentMessage.Sid
        }
    }
}

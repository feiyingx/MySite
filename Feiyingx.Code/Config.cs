using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feiyingx.Code
{
    public class Config
    {
        public static class ApplicationSettings
        {
            private static string _environmentKey = "Environment";
            public static string Environment(){
                return ConfigurationManager.AppSettings[_environmentKey];
            }
        }

        public static class ExceptionSettings
        {
            private static string _errorEmailKey = "ExceptionEmail";

            public static string ExceptionEmail()
            {
                return ConfigurationManager.AppSettings[_errorEmailKey];
            }
        }

        public static class EmailSettings
        {
            private static string _usernameKey = "SmtpUsername";
            private static string _passwordKey = "SmtpPassword";
            private static string _serverNameKey = "SmtpServerName";
            private static string _portKey = "SmtpServerPort";
            private static string _contactUsRecipientEmailKey = "ContactUsEmailRecipient";


            public static string Username()
            {
                return ConfigurationManager.AppSettings[_usernameKey];
            }

            public static string Password()
            {
                return ConfigurationManager.AppSettings[_passwordKey];
            }

            public static string HostName()
            {
                return ConfigurationManager.AppSettings[_serverNameKey];
            }

            public static int Port()
            {
                return Int32.Parse(ConfigurationManager.AppSettings[_portKey]);
            }

            public static string ContactUsRecipient()
            {
                return ConfigurationManager.AppSettings[_contactUsRecipientEmailKey];
            }
        }

        public static class TwilioSettings
        {
            private static string _accountIdKey = "TwilioAccountId";
            private static string _authTokenKey = "TwilioAuthToken";
            private static string _twilioPhoneNumberKey = "TwilioPhoneNumber";

            public static string AccountId()
            {
                return ConfigurationManager.AppSettings[_accountIdKey];
            }

            public static string AuthToken()
            {
                return ConfigurationManager.AppSettings[_authTokenKey];
            }

            public static string TwilioPhoneNumber()
            {
                return ConfigurationManager.AppSettings[_twilioPhoneNumberKey];
            }
        }
    }
}

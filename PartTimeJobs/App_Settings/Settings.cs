using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PartTimeJobs.App_Settings
{
    public static class Settings
    {
        public static string TokenKey
        {
            get
            {
                return ConfigurationManager.AppSettings["TokenKey"];
            }
        }

        public static string Secret
        {
            get
            {
                return ConfigurationManager.AppSettings["Secret"];
            }
        }

        public const string UserNameClaimKey = "UserName";
        public const string UserTypeClaimKey = "UserType";
        public const string Provider = "Provider";
        public const string Client = "Client";
    }
}
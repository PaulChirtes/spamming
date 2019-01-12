﻿using PartTimeJobs.App_Settings;
using PartTimeJobs.JWT;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PartTimeJobs.Authorization
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        { 
            if (actionContext.Request.Headers.Contains(Settings.TokenKey))
            {
                IEnumerable<string> tokenValues = new List<string>();
                actionContext.Request.Headers.TryGetValues(Settings.TokenKey, out tokenValues);
                if (tokenValues.Count() == 1)
                {
                    return JwtManager.ValidateToken(tokenValues.First());
                }
            }

             return false;
        }
    }
}
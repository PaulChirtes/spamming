using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PartTimeJobs.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {
        protected HttpResponseMessage HandleRequestSafely(Func<HttpResponseMessage> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
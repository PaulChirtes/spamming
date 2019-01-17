using PartTimeJobs.Models.ModelFactories;
using PArtTimeJobs.BLL.Services;
using PArtTimeJobs.BLL.Validator;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartTimeJobs.Controllers
{
    public class JobController : BaseController
    {
        private JobService _jobService = new JobService(new JobValidator());

        [HttpPost]
        [AllowAnonymous]
        [Route("jobs")]
        public HttpResponseMessage GetNotAssignedJobs()
        {
            return HandleRequestSafely(() =>
            {
                var jobFactory = new JobFactory();

                var jobs = _jobService.GetNotAssignedJobs();
                if (jobs != null)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Something went wrong..but idk what");
            });
        }
    }
}

using PartTimeJobs.BLL.Services;
using PartTimeJobs.Models;
using PartTimeJobs.Models.ModelFactories;
using PArtTimeJobs.BLL.Services;
using PArtTimeJobs.BLL.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartTimeJobs.Controllers
{
    public class ReviewController : BaseController
    {
        private JobService _jobService = new JobService(new JobValidator());
        private UserService _userService = new UserService();
        private ReviewService _reviewService = new ReviewService();

        [HttpGet]
        [Route("ThatShouldBeChanged")]
        public HttpResponseMessage GetReviewsForUser([FromBody] UserDto userDto)
        {
            return HandleRequestSafely(() =>
            {
                if (userDto == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Incorrect request");
                }

                var reviewFactory = new ReviewFactory();
                var userFactory = new UserFactory();
                var user = _userService.PerformLogin(userFactory.GetUserFromDto(userDto));
                if (user != null)
                {
                    var reviews = _reviewService.GetAllReviewForUser(user);
                    if (reviews != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, reviews.Select(reviewFactory.GetReviewDtoFromReview));
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Something went wrong...");
                    }
                }
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Something went wrong...");
            });
        }


    }
}

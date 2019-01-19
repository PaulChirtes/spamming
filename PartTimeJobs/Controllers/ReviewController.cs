using PartTimeJobs.App_Settings;
using PartTimeJobs.Authorization;
using PartTimeJobs.BLL.Services;
using PartTimeJobs.DAL.Models;
using PartTimeJobs.JWT;
using PartTimeJobs.Models;
using PartTimeJobs.Models.ModelFactories;
using PArtTimeJobs.BLL.Services;
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
        private JobService _jobService = new JobService();
        private UserService _userService = new UserService();
        private ReviewService _reviewService = new ReviewService();

        [HttpPost]
        [UserAuthorize]
        [Route("review")]
        public HttpResponseMessage AddJob([FromBody] ReviewDto reviewDto)
        {
            return HandleRequestSafely(() =>
            {
                if (reviewDto == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Body can't be null");
                }

                var review = new ReviewFactory().GetReview(reviewDto);
                review.Job = _jobService.GetById(review.Job.Id);
                if (review.Job == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Review doesn't exist");
                }

                if (review.Job.Asignee == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Review must have an asignee");
                }

                if (review.Job.Review == null)
                {
                    _reviewService.Add(review);
                }
                else
                {
                    review.Id = review.Job.Review.Id;
                    _reviewService.Update(review);
                }
               
                return Request.CreateResponse(HttpStatusCode.OK);
            });
        }
    }
}
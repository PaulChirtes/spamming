using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJobs.Models.ModelFactories
{
    public class ReviewFactory
    {
        public Review GetReviewFromDto(ReviewDto review)
        {
            return new Review
            {
                ReviewDesc = review.ReviewDesc,
                Assignee = new UserDetailModelFactory().GetUserFromDto(review.Assignee),
                Owner = new UserDetailModelFactory().GetUserFromDto(review.Owner),
                Job = new JobFactory().GetJobFromDto(review.Job)
            };
        }

        public ReviewDto GetReviewDtoFromReview(Review review)
        {
            return new ReviewDto
            {
                Assignee = new UserDetailModelFactory().GetUserDetailDtoFromUser(review.Assignee),
                Owner = new UserDetailModelFactory().GetUserDetailDtoFromUser(review.Owner),
                Job = new JobFactory().GetJobDtoFromJob(review.Job),
                ReviewDesc = review.ReviewDesc
            };
        }
    }
}
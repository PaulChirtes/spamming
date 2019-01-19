using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJobs.Models.ModelFactories
{
    public class ReviewFactory
    {
        public Review GetReview(ReviewDto reviewDto)
        {
            return new Review
            {
                AssigneeDescription = reviewDto.AssigneeDescription,
                OwnerDescription = reviewDto.OwnerDescription,
                Id = reviewDto.Id,
                Job = new JobFactory().GetJobFromDto(reviewDto.Job)
            };
        }
    }
}
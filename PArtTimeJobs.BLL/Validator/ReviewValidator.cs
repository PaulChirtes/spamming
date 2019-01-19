using PartTimeJobs.BLL.Validator;
using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PArtTimeJobs.BLL.Validator
{
    public class ReviewValidator : IValidator<Review>
    {
        public void Validate(Review entity)
        {
            if (string.IsNullOrEmpty(entity.ReviewDesc))
            {
                throw new ValidatorException("Review should not be empty!");
            }
        }
    }
}

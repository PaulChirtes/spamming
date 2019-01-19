using PartTimeJobs.BLL.Services;
using PartTimeJobs.BLL.Validator;
using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PArtTimeJobs.BLL.Services
{
    public class ReviewService : BaseService<Review>
    {
        public ReviewService(IValidator<Review> validator) : base(validator)
        {
        }

        public ReviewService() : base()
        {
        }
    }
}

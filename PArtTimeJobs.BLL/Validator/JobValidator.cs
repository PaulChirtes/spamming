using PartTimeJobs.BLL.Validator;
using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PArtTimeJobs.BLL.Validator
{
    public class JobValidator : IValidator<Job>
    {
        public void Validate(Job job)
        {
            if (string.IsNullOrEmpty(job.Title))
            {
                throw new ValidatorException("Title should not be empty!");
            }
            if (string.IsNullOrEmpty(job.Description))
            {
                throw new ValidatorException("Description should not be empty");
            }
        }
    }
}

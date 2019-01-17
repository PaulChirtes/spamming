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
    class JobService : BaseService<Job>
    {
        public JobService(IValidator<Job> validator) : base(validator)
        {
        }

        public JobService() : base()
        {

        }
    }
}

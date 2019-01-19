using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJobs.Models
{
    public class JobDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDetailDto Assigne { get; set; }
        public UserDetailDto Owner { get; set; }
        public JobType Type { get; set; }
    }
}
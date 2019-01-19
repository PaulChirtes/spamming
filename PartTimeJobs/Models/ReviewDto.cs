using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJobs.Models
{
    public class ReviewDto : BaseDto
    {
        public string OwnerDescription { get; set; }
        public string AssigneeDescription { get; set; }

        public JobDto Job { get; set; }

    }
}
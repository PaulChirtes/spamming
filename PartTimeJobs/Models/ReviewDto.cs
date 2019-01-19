using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJobs.Models
{
    public class ReviewDto
    {
        public UserDetailDto Owner { get; set; }
        public UserDetailDto Assignee { get; set; }
        public JobDto Job { get; set; }
        public string ReviewDesc { get; set; }
    }
}
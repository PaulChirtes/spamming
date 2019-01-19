using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeJobs.DAL.Models
{
    public class Review : BaseEntity
    {
        public User Owner { get; set; }
        public User Assignee { get; set; }
        public Job Job { get; set; }
        public string ReviewDesc;
    }
}

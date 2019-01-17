using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeJobs.DAL.Models
{
    public class Skill : BaseEntity
    {
        public string SkillName { get; set; }        
        public List<User> Users { get; set; }
    }
}

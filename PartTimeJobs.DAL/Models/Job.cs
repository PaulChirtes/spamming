using System.Collections.Generic;

namespace PartTimeJobs.DAL.Models
{
    public class Job : BaseEntity
    {
        public User Owner { get; set; }
        public User Asignee { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Skill> RequiredSkills { get; set; }
        public JobType Type { get; set; }
        public Review Review { get; set; }
    }
}

using System.Collections.Generic;

namespace PartTimeJobs.DAL.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public List<Job> JobsCreated { get; set; }
        public List<Job> JobsAssinged { get; set; }
        public List<Skill> Skills { get; set; }
    }
}

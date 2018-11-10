namespace PartTimeJobs.DAL.Models
{
    public class Job : BaseEntity
    {
        public User Owner { get; set; }
        public User Asignee { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


    }
}

using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using System.Data.Entity;
using System.Linq;

namespace PartTimeJobs.DAL.Repository
{
    class JobRepository : BaseRepository<Job>
    {
        public JobRepository(PartTimeJobsDbContext context) : base(context)
        {
        }

        public override IQueryable<Job> GetAll()
        {
            return base.GetAll()
                .Include(job => job.Asignee)
                .Include(job => job.Owner)
                .Include(job => job.Review)
                .Include(job => job.RequiredSkills);
        }

        public override Job GetById(int id)
        {
            return GetAll().FirstOrDefault(job => job.Id.Equals(id));
        }
    }
}

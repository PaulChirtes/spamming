using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using System.Data.Entity;
using System.Linq;

namespace PartTimeJobs.DAL.Repository
{
    class UserRepository  : BaseRepository<User>
    {
        public UserRepository(PartTimeJobsDbContext context) : base(context)
        {
        }

        public override IQueryable<User> GetAll()
        {
            return base.GetAll()
                .Include(user => user.JobsAssinged)
                .Include(user => user.JobsCreated)
                .Include(user => user.Skills);
        }

        public override User GetById(int id)
        {
            return GetAll().FirstOrDefault(user => user.Id.Equals(id));
        }
    }
}

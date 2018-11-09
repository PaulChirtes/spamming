using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeJobs.DAL.Repository
{
    class UserRepository  : BaseRepository<User>
    {
        public UserRepository(PartTimeJobsDbContext context) : base(context)
        { }

        public override IQueryable<User> GetAll()
        {
            return base.GetAll()
                .Include(user => user.JobsAssinged)
                .Include(user => user.JobsCreated)
                .Include(user => user.JobsCreated.Select(job => job.Owner))
                .Include(user => user.JobsAssinged.Select(job => job.Asignee));
        }
    }
}

using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using System.Data.Entity;
using System.Linq;

namespace PartTimeJobs.DAL.Repository
{
    class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(PartTimeJobsDbContext context) : base(context)
        {
        }

        public override IQueryable<Review> GetAll()
        {
            return base.GetAll()
                .Include(review => review.Assignee)
                .Include(review => review.Owner)
                .Include(review => review.Job);
        }

        public override Review GetById(int id)
        {
            return GetAll().FirstOrDefault(review => review.Id.Equals(id));
        }
    }
}

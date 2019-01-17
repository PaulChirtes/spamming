using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeJobs.DAL.Repository
{
    class SkillsRepository:BaseRepository<Skill>
    {
        public SkillsRepository(PartTimeJobsDbContext context) : base(context)
        {
        }
    }
}

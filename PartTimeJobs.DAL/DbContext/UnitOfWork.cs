using PartTimeJobs.DAL.Models;
using PartTimeJobs.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeJobs.DAL.DbContext
{
    public static class UnitOfWork
    {
        static PartTimeJobsDbContext _dbContext = new PartTimeJobsDbContext();

        public static void Create()
        {
            _dbContext.Database.CreateIfNotExists();
        }

        public static void Commit()
        {
            _dbContext.SaveChanges();
        }

        public static IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            Assembly repositoryAssembly = typeof(IRepository<T>).Assembly;
            Type repositoryType = repositoryAssembly.GetTypes()
                .Where(type => type.BaseType != null && type.BaseType.Equals(typeof(BaseRepository<T>)))
                .FirstOrDefault();

            return repositoryType == null ? null : Activator.CreateInstance(repositoryType, _dbContext) as IRepository<T>;
        }
    }
}

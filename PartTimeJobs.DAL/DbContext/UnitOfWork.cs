using PartTimeJobs.DAL.Models;
using PartTimeJobs.DAL.Repository;
using System;
using System.Linq;
using System.Reflection;

namespace PartTimeJobs.DAL.DbContext
{
    public static class UnitOfWork
    {
        static PartTimeJobsDbContext _dbContext = new PartTimeJobsDbContext();

        public static void Create()
        {
            _dbContext.Database.Delete();
            _dbContext.Database.CreateIfNotExists();
        }

        public static void Commit()
        {
            _dbContext.SaveChanges();
        }

        public static void Revert()
        {
            _dbContext.Dispose();
            _dbContext = new PartTimeJobsDbContext();
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

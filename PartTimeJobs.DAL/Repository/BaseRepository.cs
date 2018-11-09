using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeJobs.DAL.Repository
{
    abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        DbSet<T> _dbSet;
        PartTimeJobsDbContext _context;
        public BaseRepository(PartTimeJobsDbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            _context.Entry(GetById(id)).State = EntityState.Deleted;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id.Equals(id));
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        protected void SetEntityProperties(PropertyInfo[] properties, T oldEntity, T entity)
        {
            foreach (var prop in properties)
            {
                var oldEntityPropValue = prop.GetValue(oldEntity);
                var entityPropValue = prop.GetValue(entity);
                if (oldEntityPropValue != null && entityPropValue != null)
                {
                    if (!oldEntityPropValue.Equals(entityPropValue))
                    {
                        prop.SetValue(oldEntity, entityPropValue);
                    }
                }
            }
        }
    }
}

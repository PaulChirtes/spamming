using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace PartTimeJobs.DAL.Repository
{
    abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        DbSet<T> _dbSet;
        PartTimeJobsDbContext _context;
        Type[] _allowedTypes = new Type[] { typeof(string), typeof(int), typeof(DateTime), typeof(long), typeof(double), typeof(float), typeof(UserType) };
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

        public virtual T GetById(int id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id.Equals(id));
        }

        public void Update(T entity)
        {
            T oldEntity = GetById(entity.Id);
            
            PropertyInfo[] properties = typeof(T).GetRuntimeProperties()
                .Where(info => info.PropertyType != null && _allowedTypes.Contains(info.PropertyType))
                .ToArray();
            SetEntityProperties(properties, oldEntity, entity);
            _context.Entry(oldEntity).State = EntityState.Modified;
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
                else
                {
                    if(entityPropValue != null)
                    {
                        prop.SetValue(oldEntity, entityPropValue);
                    }
                }
            }
        }
    }
}

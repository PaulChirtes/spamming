using PartTimeJobs.DAL.Models;
using System.Linq;

namespace PartTimeJobs.DAL.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

using PartTimeJobs.DAL.Models;

namespace PartTimeJobs.BLL.Validator
{
    public interface IValidator<T> where T : BaseEntity
    {
        void Validate(T entity);
    }
}

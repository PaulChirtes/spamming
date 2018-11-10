using PartTimeJobs.DAL.Models;

namespace PArtTimeJobs.BLL.Validator
{
    public interface IValidator<T> where T : BaseEntity
    {
        void Validate(T entity);
    }
}

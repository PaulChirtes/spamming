using PartTimeJobs.DAL.Models;
using PartTimeJobs.BLL.Cryptography;
using PartTimeJobs.BLL.Validator;
using System.Linq;

namespace PartTimeJobs.BLL.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(IValidator<User> validator) : base(validator)
        {
        }

        public UserService() : base()
        {
        }

        public override void Add(User user)
        {
            user.Password = !string.IsNullOrEmpty(user.Password) ? Crypto.Encrypt(user.Password) : string.Empty;
            if (_repository.GetAll().Any(u => u.Email.Equals(user.Email)))
            {
                throw new ValidatorException("There is already a user with this email");
            }
            base.Add(user);
        }

        public User PerformLogin(User user)
        {
            user.Password = Crypto.Encrypt(user.Password);
            return _repository.GetAll().FirstOrDefault(u => u.Password.Equals(user.Password) && u.Email.Equals(u.Email));
        }

        public bool UserExists(string email)
        {
            return _repository.GetAll().Any(user => user.Email.Equals(email));
        }
    }
}

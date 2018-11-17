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
            base.Add(user);
        }

        public User PerformLogin(User user)
        {
            _validator.Validate(user);
            user.Password = Crypto.Encrypt(user.Password);
            return _repository.GetAll().FirstOrDefault(u => u.Password.Equals(user.Password) && u.UserName.Equals(u.UserName));
        }

        public bool UserExists(string userName)
        {
            return _repository.GetAll().Any(user => user.UserName.Equals(userName));
        }
    }
}

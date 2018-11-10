using PartTimeJobs.DAL.Models;
using PArtTimeJobs.BLL.Cryptography;
using PArtTimeJobs.BLL.Validator;

namespace PArtTimeJobs.BLL.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(IValidator<User> validator) : base(validator)
        {
        }

        public override void Add(User user)
        {
            user.Password = !string.IsNullOrEmpty(user.Password) ? Crypto.Encrypt(user.Password) : string.Empty;
            base.Add(user);
        }
    }
}

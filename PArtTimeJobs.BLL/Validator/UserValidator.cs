using PartTimeJobs.DAL.Models;

namespace PartTimeJobs.BLL.Validator
{
    public class UserValidator : IValidator<User>
    {
        public void Validate(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                throw new ValidatorException("User name shouldn't be empty");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ValidatorException("Password shouldn't be empty");
            }
        }
    }
}

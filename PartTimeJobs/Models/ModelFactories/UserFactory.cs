using PartTimeJobs.DAL.Models;

namespace PartTimeJobs.Models.ModelFactories
{
    public class UserFactory
    {
        public User GetUserFromDto(UserDto userDto)
        {
            return new User
            {
                UserName = userDto.UserName,
                Password = userDto.Password
            };
        }
    }
}
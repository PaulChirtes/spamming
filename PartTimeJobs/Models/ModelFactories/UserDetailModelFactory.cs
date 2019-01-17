using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJobs.Models.ModelFactories
{
    public class UserDetailModelFactory
    {
        public User GetUserFromDto(UserDetailDto userDetailDto)
        {
            return new User
            {
                Id = userDetailDto.Id,
                UserName = userDetailDto.UserName,
                Password = userDetailDto.Password,
                UserType = userDetailDto.UserType,
                Email = userDetailDto.Email,
                PhoneNumber = userDetailDto.PhoneNumber
            };
        }

        public UserProfileDto GetUserProfileDto(User user)
        {
            return new UserProfileDto
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        public UserDetailDto GetUserDetailDtoFromUser(User user)
        {
            return new UserDetailDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                UserType = user.UserType
            };
        }
    }
}
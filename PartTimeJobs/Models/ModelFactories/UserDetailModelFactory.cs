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
    }
}
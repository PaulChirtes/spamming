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
                PhoneNumber = user.PhoneNumber,
                Type = user.UserType,
                Skills = user.Skills == null ?
                        new List<string>() :
                        user.Skills.Select(skill => skill.SkillName).ToList()
            };
        }

        public User GetUserFromUserProfile(UserProfileDto userProfileDto)
        {
            return new User
            {
                Id = userProfileDto.Id,
                Email = userProfileDto.Email,
                PhoneNumber = userProfileDto.PhoneNumber,
                UserName = userProfileDto.Username,
                Skills = userProfileDto.Skills == null ? null :
                         userProfileDto.Skills.Select(skill => new Skill { SkillName = skill }).ToList()
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJobs.Models
{
    public class UserProfileDto: UserDto
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
    }
}
using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJobs.Models
{
    public class UserDetailDto : UserDto

    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
    }
}
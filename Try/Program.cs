﻿using PartTimeJobs.BLL.Services;
using PartTimeJobs.BLL.Validator;
using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;

namespace Try
{
    class Program
    {
        static void Main(string[] args)
        {
            //UnitOfWork.Create();
            //var service = new UserService(new UserValidator());
            //var a = service.GetUserByEmail("admin@admin.com");
            //service.Add(new User { UserName = "admin", Password = "admin", UserType = UserType.Provider,Email="admin@admin.com" });
            var skillservice = new SkillService();
            //skillservice.Add(new Skill { SkillName = "funny" });
            var skill = skillservice.GetSkillByName("smart");
            var skill2 = skillservice.GetSkillByName("funny");
            var skill3 = skillservice.GetSkillByName("god");


        }
    }
}

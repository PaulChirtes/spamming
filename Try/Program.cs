using PartTimeJobs.BLL.Services;
using PartTimeJobs.BLL.Validator;
using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using PArtTimeJobs.BLL.Services;

namespace Try
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork.Create();
            //var service = new UserService(new UserValidator());
            //var a = service.GetUserByEmail("admin@admin.com");
            //service.Add(new User { UserName = "User1", Password = "pass1", UserType = UserType.Provider, Email = "test@test.test" });
            //service.Add(new User { UserName = "User2", Password = "pass2", UserType = UserType.Client, Email = "test@test2.test" });
            //service.Add(new User { UserName = "admin", Password = "admin", UserType = UserType.Provider,Email="admin@admin.com" });
            //service.Add(new User { UserName = "Corporatie", Password = "corporatie", UserType = UserType.Provider, Email = "corporatie@corporatie.com" });
            //service.Add(new User { UserName = "sclav", Password = "sclav", UserType = UserType.Provider, Email = "sclav@sclav.com" });
            ////service.Add(new User { UserName = "user", Password = "user", UserType = UserType.Client, Email = "user@user.com" });
            ////var skillservice = new SkillService();
            ////skillservice.Add(new Skill { SkillName = "funny" });
            ////var skill = skillservice.GetSkillByName("smart");
            ////var skill2 = skillservice.GetSkillByName("funny");
            ////var skill3 = skillservice.GetSkillByName("god");
            //var a = service.GetUserByEmail("admin@admin.com");

            //var jobService = new JobService();
            //jobService.Add(new Job { Owner = a, Title = "Un job", Description = "A new job that is amazing" ,Type=JobType.Food});
            //jobService.Add(new Job { Owner = a, Title = "Un job 2", Description = "A new job that is amazing 2",Type=JobType.Other});
            //jobService.Add(new Job { Owner = a, Title = "Un job 3", Description = "A new job that is amazing 3" ,Type=JobType.Photography});
            //jobService.Add(new Job { Owner = a, Title = "Un job 4", Description = "A new job that is amazing 4",Type=JobType.School });
            //jobService.Add(new Job { Owner = a, Title = "Un job 5", Description = "A new job that is amazing 5",Type=JobType.Sport });

            //a = service.GetUserByEmail("corporatie@corporatie.com");
            //jobService.Add(new Job { Owner = a, Title = "Un job 6", Description = "A new job that is amazing 6", Type = JobType.Food });
            //jobService.Add(new Job { Owner = a, Title = "Un job 7", Description = "A new job that is amazing 7", Type = JobType.Other });
            //jobService.Add(new Job { Owner = a, Title = "Un job 8", Description = "A new job that is amazing 8", Type = JobType.Photography });
            //jobService.Add(new Job { Owner = a, Title = "Un job 9", Description = "A new job that is amazing 9", Type = JobType.School });
            //jobService.Add(new Job { Owner = a, Title = "Un job 10", Description = "A new job that is amazing 10", Type = JobType.Sport });

            //jobService.Add(new Job { Owner = a, Title = "Un job 11", Description = "A new job that is amazing 11", Type = JobType.Food });
            //jobService.Add(new Job { Owner = a, Title = "Un job 12", Description = "A new job that is amazing 12", Type = JobType.Other });
            //jobService.Add(new Job { Owner = a, Title = "Un job 13", Description = "A new job that is amazing 13", Type = JobType.Photography });
            //jobService.Add(new Job { Owner = a, Title = "Un job 14", Description = "A new job that is amazing 14", Type = JobType.School });
            //jobService.Add(new Job { Owner = a, Title = "Un job 15", Description = "A new job that is amazing 15", Type = JobType.Sport });


        }
    }
}

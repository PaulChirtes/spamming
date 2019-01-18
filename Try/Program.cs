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
            //UnitOfWork.Create();
            var service = new UserService(new UserValidator());
            var a = service.GetUserByEmail("admin@admin.com");
            //service.Add(new User { UserName = "User1", Password = "pass1", UserType = UserType.Provider, Email = "test@test.test" });
            //service.Add(new User { UserName = "User2", Password = "pass2", UserType = UserType.Client, Email = "test@test2.test" });
            //service.Add(new User { UserName = "admin", Password = "admin", UserType = UserType.Provider,Email="admin@admin.com" });
            //service.Add(new User { UserName = "user", Password = "user", UserType = UserType.Client, Email = "user@user.com" });
            //var skillservice = new SkillService();
            //skillservice.Add(new Skill { SkillName = "funny" });
            //var skill = skillservice.GetSkillByName("smart");
            //var skill2 = skillservice.GetSkillByName("funny");
            //var skill3 = skillservice.GetSkillByName("god");
            var jobService = new JobService();
            jobService.Add(new Job { Owner = a, Title = "Un job", Description = "A new job that is amazing" });
            jobService.Add(new Job { Owner = a, Title = "Un job 2", Description = "A new job that is amazing 2" });
            jobService.Add(new Job { Owner = a, Title = "Un job 3", Description = "A new job that is amazing 3" });
            jobService.Add(new Job { Owner = a, Title = "Un job 4", Description = "A new job that is amazing 4" });
            jobService.Add(new Job { Owner = a, Title = "Un job 5", Description = "A new job that is amazing 5" });


        }
    }
}

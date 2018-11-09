using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;
using PartTimeJobs.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork.Create();
            var repo = UnitOfWork.GetRepository<User>();
            var provider = new User { Email = "a@a.com", Password = "plm", UserName = "fds", UserType = UserType.Provider };
            repo.Add(provider);
            var client = new User { Email = "a@a.com", Password = "plm", UserName = "fds", UserType = UserType.Client };
            repo.Add(client);
            repo.GetAll().Where(user => user.UserType == UserType.Client).ToList().ForEach(user => Console.WriteLine(user.UserName));

            var jobRepo = UnitOfWork.GetRepository<Job>();
            jobRepo.Add(new Job { Asignee = client, Owner = provider, Title = "titlu", Description = "tocanita" });
            UnitOfWork.Commit();
            var jobs = jobRepo.GetAll().ToList();

        }
    }
}

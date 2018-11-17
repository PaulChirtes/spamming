using PartTimeJobs.BLL.Services;
using PartTimeJobs.BLL.Validator;
using PartTimeJobs.DAL.DbContext;
using PartTimeJobs.DAL.Models;

namespace Try
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork.Create();
            var service = new UserService(new UserValidator());
            service.Add(new User { UserName = "admin", Password = "admin", UserType = UserType.Provider });
        }
    }
}

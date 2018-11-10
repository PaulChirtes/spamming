using System.Web.Http;
using WebActivatorEx;
using PartTimeJobs;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace PartTimeJobs
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "PartTimeJobs");
                    });
        }
    }
}

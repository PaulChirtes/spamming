using PartTimeJobs.Models;
using PartTimeJobs.Models.ModelFactories;
using PartTimeJobs.BLL.Services;
using PartTimeJobs.BLL.Validator;
using System.Net.Http;
using System.Web.Http;
using PartTimeJobs.JWT;
using System.Net;
using System.Web;
using PartTimeJobs.App_Settings;
using PartTimeJobs.Authorization;

namespace PartTimeJobs.Controllers
{
    public class UserController : BaseController
    {
        private UserFactory _userFactory = new UserFactory();
        private UserService _userService = new UserService(new UserValidator());

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public HttpResponseMessage PerformLogin([FromBody] UserDto userDto)
        {
            return HandleRequestSafely(() =>
            {
                if (userDto == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Incorrect request");
                }

                DAL.Models.User user = _userService.PerformLogin(_userFactory.GetUserFromDto(userDto));
                if (user != null)
                {
                    var response =  Request.CreateResponse(HttpStatusCode.OK);
                    response.Headers.Add(Settings.TokenKey, JwtManager.GenerateToken(user));
                    response.Headers.Add("Access-Control-Expose-Headers", Settings.TokenKey);
                    return response;
                }

                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Username and/or password are incorect");
            });
        }

        [UserAuthorize]
        [Route("test")]
        public HttpResponseMessage Get()
        {
            return HandleRequestSafely(() => Request.CreateResponse(HttpStatusCode.OK,"mere"));
        }
    }
}
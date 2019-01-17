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
using System.Collections.Generic;
using System.Linq;

namespace PartTimeJobs.Controllers
{
    public class UserController : BaseController
    {
        private UserService _userService = new UserService(new UserValidator());
        private SkillService _skillService = new SkillService();

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
                userDto.Password = JwtManager.DecryptBase64(userDto.Password);
                userDto.Email = JwtManager.DecryptBase64(userDto.Email);

                var userFactory = new UserFactory();
                var user = _userService.PerformLogin(userFactory.GetUserFromDto(userDto));
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


        //This is an example for authorize
        //[UserAuthorize]
        //[Route("test")]
        //public HttpResponseMessage Get()
        //{
        //    return HandleRequestSafely(() => Request.CreateResponse(HttpStatusCode.OK,"mere"));
        //}

        [Route("register")]
        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage Register([FromBody] UserDetailDto userDetailDto)
        {
            return HandleRequestSafely(() =>
            {
                if (userDetailDto == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "User can't be null");
                }

                var userDetailModelFactory = new UserDetailModelFactory();
                var user = userDetailModelFactory.GetUserFromDto(userDetailDto);
                _userService.Add(user);

                return Request.CreateResponse(HttpStatusCode.OK);
            });
        }

        [UserAuthorize]
        [Route("profile")]
        [HttpGet]
        public HttpResponseMessage GetUserDetails()
        {
            return HandleRequestSafely(() =>
            {
                IEnumerable<string> tokenValues = new List<string>();
                Request.Headers.TryGetValues(Settings.TokenKey, out tokenValues);
                var user = _userService.GetUserByEmail(JwtManager.GetEmailFromToken(tokenValues.First()));

                var userDetailModelFactory = new UserDetailModelFactory();
                var userProfile = userDetailModelFactory.GetUserProfileDto(user);
                if (user.UserType == DAL.Models.UserType.Provider)
                {
                    userProfile.Skills = null;
                }
                return Request.CreateResponse(HttpStatusCode.OK, userProfile);
            });
        }

    }
}

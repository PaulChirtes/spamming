using PartTimeJobs.App_Settings;
using PartTimeJobs.Authorization;
using PartTimeJobs.BLL.Services;
using PartTimeJobs.DAL.Models;
using PartTimeJobs.JWT;
using PartTimeJobs.Models;
using PartTimeJobs.Models.ModelFactories;
using PArtTimeJobs.BLL.Services;
using PArtTimeJobs.BLL.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartTimeJobs.Controllers
{
    public class JobController : BaseController
    {
        private JobService _jobService = new JobService(new JobValidator());
        private UserService _userService = new UserService();
        private SkillService _skillService = new SkillService();


        [HttpGet]
        [Route("unassignedJobs")]
        public HttpResponseMessage GetNotAssignedJobs()
        {
            return HandleRequestSafely(() =>
            {
                var jobFactory = new JobFactory();

                var jobs = _jobService.GetNotAssignedJobs();
                if (jobs != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, jobs.Select(jobFactory.GetJobDtoFromJob));
                }
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Something went wrong...");
            });
        }

        [HttpGet]
        [Route("jobsByType/{type}")]
        public HttpResponseMessage GetJobsByType(int type)
        {
            return HandleRequestSafely(() =>
            {
                var jobType = (JobType)Enum.ToObject(typeof(JobType), type);
                var jobFactory = new JobFactory();
                var jobs = _jobService.GetJobsByType(jobType);
                if (jobs != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, jobs.Select(jobFactory.GetJobDtoFromJob));
                }
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Something went wrong...");
            });
        }

        [HttpGet]
        [UserAuthorize]
        [Route("createdJobs")]
        public HttpResponseMessage GetUserCreatedJobs()
        {
            return HandleRequestSafely(() =>
            {
                IEnumerable<string> tokenValues = new List<string>();
                Request.Headers.TryGetValues(Settings.TokenKey, out tokenValues);
                var user = _userService.GetUserByEmail(JwtManager.GetEmailFromToken(tokenValues.First()));
                var jobs = user.JobsCreated ?? new List<Job>();
                var jobFactory = new JobFactory();
                return Request.CreateResponse(HttpStatusCode.OK, jobs.Select(jobFactory.GetJobDtoFromJob));
            });
        }

        [HttpGet]
        [Route("getJob/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            return HandleRequestSafely(() =>
            {
                var job = _jobService.GetById(id);
                if (job == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is no job with that id");
                }
                var jobFactory = new JobFactory();
                return Request.CreateResponse(HttpStatusCode.OK, jobFactory.GetJobDtoFromJob(job));
            });
        }

        [HttpGet]
        [UserAuthorize]
        [Route("assignedJobs")]
        public HttpResponseMessage GetUserAssigned()
        {
            return HandleRequestSafely(() =>
            {
                IEnumerable<string> tokenValues = new List<string>();
                Request.Headers.TryGetValues(Settings.TokenKey, out tokenValues);
                var user = _userService.GetUserByEmail(JwtManager.GetEmailFromToken(tokenValues.First()));
                var jobs = user.JobsAssinged ?? new List<Job>();
                var jobFactory = new JobFactory();
                return Request.CreateResponse(HttpStatusCode.OK, jobs.Select(jobFactory.GetJobDtoFromJob));
            });
        }

        [HttpPost]
        [UserAuthorize]
        [Route("job")]
        public HttpResponseMessage AddJob([FromBody] JobDto jobDto)
        {
            return HandleRequestSafely(() =>
            {
                IEnumerable<string> tokenValues = new List<string>();
                Request.Headers.TryGetValues(Settings.TokenKey, out tokenValues);
                var user = _userService.GetUserByEmail(JwtManager.GetEmailFromToken(tokenValues.First()));
                if (user.UserType != UserType.Provider)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Only providers can create jobs");
                }
                var job = new JobFactory().GetJobFromDto(jobDto);
                job.Owner = user;
                job.Asignee = null;
                if (jobDto.Skills != null)
                {
                    job.RequiredSkills = jobDto.Skills.Select(skill => _skillService.GetSkillByName(skill)).ToList();
                }
                _jobService.Add(job);
                return Request.CreateResponse(HttpStatusCode.OK);
            });
        }

        [HttpPut]
        [UserAuthorize]
        [Route("updateJob")]
        public HttpResponseMessage UpdateJob([FromBody] JobDto jobDto)
        {
            return HandleRequestSafely(() =>
            {
                IEnumerable<string> tokenValues = new List<string>();
                Request.Headers.TryGetValues(Settings.TokenKey, out tokenValues);
                var user = _userService.GetUserByEmail(JwtManager.GetEmailFromToken(tokenValues.First()));
                if (user.UserType != UserType.Provider)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Only providers can update jobs");
                }
                var job = new JobFactory().GetJobFromDto(jobDto);
                job.Owner = user;
                _jobService.Update(job);
                return Request.CreateResponse(HttpStatusCode.OK);
            });
        }

        [HttpPut]
        [UserAuthorize]
        [Route("applyToJob/{id}")]
        public HttpResponseMessage Apply(int id)
        {
            return HandleRequestSafely(() =>
            {
                IEnumerable<string> tokenValues = new List<string>();
                Request.Headers.TryGetValues(Settings.TokenKey, out tokenValues);
                var user = _userService.GetUserByEmail(JwtManager.GetEmailFromToken(tokenValues.First()));
                var job = _jobService.GetById(id);
                if (job == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Something went wrong...");
                }

                if (!CheckSkills(job, user))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You lack some required skills");
                }

                job.Asignee = user;
                _jobService.Update(job);
                return Request.CreateResponse(HttpStatusCode.OK);
            });
        }

        [HttpPut]
        [UserAuthorize]
        [Route("unapplyToJob/{id}")]
        public HttpResponseMessage Unapply(int id)
        {
            return HandleRequestSafely(() =>
            {
                IEnumerable<string> tokenValues = new List<string>();
                Request.Headers.TryGetValues(Settings.TokenKey, out tokenValues);
                var user = _userService.GetUserByEmail(JwtManager.GetEmailFromToken(tokenValues.First()));
                var job = _jobService.GetById(id);
                if (job == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Something went wrong...");
                }

                if (job.Owner == user || job.Asignee == user)
                {
                    job.Asignee = null;
                    _jobService.Update(job);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            });
        }

        private bool CheckSkills(Job job, User user)
        {
            if(job.RequiredSkills==null || !job.RequiredSkills.Any())
            {
                return true;
            }

            if(user.Skills==null || !user.Skills.Any())
            {
                return job.RequiredSkills == null || !job.RequiredSkills.Any();
            }

            return job.RequiredSkills.All(skill => user.Skills.Any(s => s.SkillName.ToLower().Equals(skill.SkillName.ToLower())));
        }
    }
}

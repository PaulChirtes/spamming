using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJobs.Models.ModelFactories
{
    public class JobFactory
    {
        public Job GetJobFromDto(JobDto jobDto)
        {
            return new Job
            {
                Title = jobDto.Title,
                Description = jobDto.Description,
                Asignee = new UserDetailModelFactory().GetUserFromDto(jobDto.Assigne),
                Owner = new UserDetailModelFactory().GetUserFromDto(jobDto.Owner),
                Id = jobDto.Id,
                Type = jobDto.Type
            };
        }

        public JobDto GetJobDtoFromJob(Job job)
        {
            return new JobDto
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Assigne = new UserDetailModelFactory().GetUserDetailDtoFromUser(job.Asignee),
                Owner = new UserDetailModelFactory().GetUserDetailDtoFromUser(job.Owner),
                Type = job.Type,
                Skills = job.RequiredSkills == null ? new List<string>() : job.RequiredSkills.Select(skill => skill.SkillName).ToList()
            };
        }
    }
}
using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeJobs.BLL.Services
{
    public class SkillService : BaseService<Skill>
    {
        public Skill GetSkillByName(string skillname)
        {
            if (!_repository.GetAll().Any(s => s.SkillName.Equals(skillname.ToLower())))
            {
                base.Add(new Skill
                {
                    SkillName = skillname.ToLower()
                });
            }

            return _repository.GetAll().FirstOrDefault(s => s.SkillName.Equals(skillname.ToLower()));
        }

        public override void Add(Skill entity)
        {
            entity.SkillName = entity.SkillName.ToLower();
            base.Add(entity);
        }
    }
}

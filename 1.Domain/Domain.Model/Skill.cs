using Core;
using Domain.Model.Enum;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Skill: DescriptiveEntity<int>
    {
        public SkillType Type { get; set; }

        public IList<CandidateSkill> CandidateSkills { get; set; }
    }
}

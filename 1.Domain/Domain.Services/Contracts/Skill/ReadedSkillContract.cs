using Domain.Services.Contracts.SkillType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Contracts.Skill
{
    public class ReadedSkillContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
}

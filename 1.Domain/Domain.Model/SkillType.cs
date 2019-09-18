using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class SkillType: DescriptiveEntity<int>
    {
        public ICollection<Skill> Skills { get; set; }
    }
}

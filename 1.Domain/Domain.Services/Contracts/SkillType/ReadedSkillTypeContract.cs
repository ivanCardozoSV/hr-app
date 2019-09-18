using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Contracts.SkillType
{
    public class ReadedSkillTypeContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

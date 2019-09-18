using ApiServer.Contracts.SkillType;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Skills
{
    public class CreateSkillViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
}

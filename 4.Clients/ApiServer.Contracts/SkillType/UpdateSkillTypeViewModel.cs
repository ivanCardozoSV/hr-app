using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.SkillType
{
    public class UpdateSkillTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

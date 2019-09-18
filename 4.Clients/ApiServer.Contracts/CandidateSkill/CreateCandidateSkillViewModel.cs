using ApiServer.Contracts.Candidates;
using ApiServer.Contracts.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.CandidateSkill
{
    public class CreateCandidateSkillViewModel
    {
        public int CandidateId { get; set; }
        public CreateCandidateViewModel Candidate { get; set; }
        public int SkillId { get; set; }
        public CreateSkillViewModel Skill { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
    }
}

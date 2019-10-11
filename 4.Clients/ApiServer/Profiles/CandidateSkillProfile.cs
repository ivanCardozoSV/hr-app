using ApiServer.Contracts.CandidateSkill;
using AutoMapper;
using Domain.Services.Contracts.CandidateSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Profiles
{
    public class CandidateSkillProfile: Profile
    {
        public CandidateSkillProfile()
        {
            CreateMap<CreateCandidateSkillViewModel, CreateCandidateSkillContract>();
            CreateMap<CreatedCandidateSkillContract, CreatedCandidateSkillViewModel>();
            CreateMap<ReadedCandidateSkillContract, ReadedCandidateSkillViewModel>();
            CreateMap<ReadedCandidateAppSkillContract, ReadedCandidateAppSkillViewModel>();
            CreateMap<UpdateCandidateSkillViewModel, UpdateCandidateSkillContract>();
        }
    }
}

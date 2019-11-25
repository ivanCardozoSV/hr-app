using AutoMapper;
using Domain.Model;
using Domain.Services.Contracts.CandidateProfile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.CandidateProfiles
{
    public class CandidateProfileProfile : AutoMapper.Profile
    {
        public CandidateProfileProfile()
        {
            CreateMap<CandidateProfile, ReadedCandidateProfileContract>();
            CreateMap<ReadedCandidateProfileContract, CandidateProfile>();
            CreateMap<CreateCandidateProfileContract, CandidateProfile>();
            CreateMap<CandidateProfile, CreatedCandidateProfileContract>();
            CreateMap<UpdateCandidateProfileContract, CandidateProfile>();
        }
    }
}

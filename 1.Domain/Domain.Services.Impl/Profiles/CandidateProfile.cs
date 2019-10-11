using AutoMapper;
using Domain.Model;
using Domain.Model.Enum;
using Domain.Services.Contracts.Candidate;
using System;

namespace Domain.Services.Impl.Profiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, ReadedCandidateContract>().ForMember(x => x.Recruiter, opt => opt.MapFrom(r => r.Recruiter.Id))
                .ForMember(x => x.PreferredOfficeId, opt => opt.MapFrom(r => r.PreferredOffice.Id));
            CreateMap<CreateCandidateContract, Candidate>()
                .ForMember(destination => destination.EnglishLevel,
                opt => opt.MapFrom(source => Enum.GetName(typeof(EnglishLevel), source.EnglishLevel)))
                .ForMember(x => x.Recruiter, opt => opt.Ignore())
                .ForMember(x => x.PreferredOffice, opt => opt.Ignore());
            CreateMap<Candidate, CreatedCandidateContract>();

            CreateMap<Candidate, ReadedCandidateAppContract>().ForMember(x => x.Recruiter, opt => opt.MapFrom(r => r.Recruiter))
           .ForMember(x => x.PreferredOffice, opt => opt.MapFrom(r => r.PreferredOffice));
         
            CreateMap<UpdateCandidateContract, Candidate>()
                .ForMember(destination => destination.EnglishLevel,
                opt => opt.MapFrom(source => Enum.GetName(typeof(EnglishLevel), source.EnglishLevel)))
                .ForMember(x => x.Recruiter, opt => opt.Ignore())
                .ForMember(x => x.PreferredOffice, opt => opt.Ignore());
        }
    }
}

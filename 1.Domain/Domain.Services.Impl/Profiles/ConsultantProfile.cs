using AutoMapper;
using Domain.Model;
using Domain.Services.Contracts.Consultant;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Impl.Profiles
{
    public class ConsultantProfile : Profile
    {
        public ConsultantProfile()
        {
            CreateMap<Consultant, CreatedConsultantContract>();
            CreateMap<UpdateConsultantContract, Consultant>();

            CreateMap<CreateConsultantContract, Consultant>();
            CreateMap<Consultant, ReadedConsultantContract>();
            CreateMap<List<Consultant>, ReadedConsultantByNameContract>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(x => x.Count))
                .ForMember(dest => dest.Results, opt => opt.MapFrom(source => source.Count > 0 ? source.Select(p =>
                    new ReadedConsultantContract
                    {
                        Id = p.Id,
                        Name = p.Name,
                        LastName = p.LastName,
                        EmailAddress = p.EmailAddress,
                        PhoneNumber = p.PhoneNumber,
                        AdditionalInformation = p.AdditionalInformation
                    }).ToList() : new List<ReadedConsultantContract>()));
        }
    }
}
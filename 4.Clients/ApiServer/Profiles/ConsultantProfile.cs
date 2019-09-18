using ApiServer.Contracts.Consultant;
using AutoMapper;
using Domain.Services.Contracts.Consultant;

namespace ApiServer.Profiles
{
    public class ConsultantProfile : Profile
    {
        public ConsultantProfile()
        {
            CreateMap<CreateConsultantViewModel, CreateConsultantContract>();
            CreateMap<ReadedConsultantContract, ReadedConsultantViewModel>();
            CreateMap<UpdateConsultantViewModel, UpdateConsultantContract>();
            CreateMap<CreatedConsultantContract, CreatedConsultantViewModel>();
        }
    }
}

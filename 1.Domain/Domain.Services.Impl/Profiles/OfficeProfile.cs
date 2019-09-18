using AutoMapper;
using Domain.Model;
using Domain.Services.Contracts.Office;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Services.Impl.Profiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, ReadedOfficeContract>();
            CreateMap<CreateOfficeContract, Office>();
            CreateMap<Office, CreatedOfficeContract>();
            CreateMap<UpdateOfficeContract, Office>();
        }
    }
}

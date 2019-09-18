using ApiServer.Contracts.Stage;
using AutoMapper;
using Domain.Services.Contracts.Stage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Profiles
{
    public class HrStageProfile : Profile
    {
        public HrStageProfile()
        {
            CreateMap<CreateHrStageViewModel, CreateHrStageContract>();
            CreateMap<CreatedHrStageContract, CreatedHrStageViewModel>();
            CreateMap<ReadedHrStageContract, ReadedHrStageViewModel>();
            CreateMap<UpdateHrStageViewModel, UpdateHrStageContract>();
        }
    }
}

using AutoMapper;
using Domain.Model;
using Domain.Services.Contracts.Community;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Services.Impl.Profiles
{
    public class CommunityProfile : AutoMapper.Profile
    {
        public CommunityProfile()
        {
            CreateMap<Community, ReadedCommunityContract>();
            CreateMap<CreateCommunityContract, Community>();
            CreateMap<Community, CreatedCommunityContract>();
            CreateMap<UpdateCommunityContract, Community>();
        }
    }
}

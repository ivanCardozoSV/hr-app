using AutoMapper;
using Domain.Model;
using Domain.Services.Contracts.Room;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Services.Impl.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, ReadedRoomContract>();
            CreateMap<CreateRoomContract, Room>();
            CreateMap<Room, CreatedRoomContract>();
            CreateMap<UpdateRoomContract, Room>();
        }
    }
}

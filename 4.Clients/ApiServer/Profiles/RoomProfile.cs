using ApiServer.Contracts.Room;
using Domain.Services.Contracts.Room;
using System.Collections.Generic;
using System.Collections;
using AutoMapper;
using ApiServer.Profiles;

namespace ApiServer.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<CreateRoomViewModel, CreateRoomContract>();
            CreateMap<CreatedRoomContract, CreatedRoomViewModel>();
            CreateMap<ReadedRoomContract, ReadedRoomViewModel>();
            CreateMap<UpdateRoomViewModel, UpdateRoomContract>();
        }

        //private static string ConverToString(System.Type propertyType, object propertyValue)
        //{
        //    var enumProperty = propertyValue as IEnumerable;
        //    if (enumProperty != null && propertyType != typeof(string))
        //    {
        //        var stringValues = new List<string>();
        //        foreach (var item in enumProperty)
        //        {
        //            stringValues.Add(item.ToString());
        //        }
        //        return string.Join(",", stringValues);
        //    }
        //    return propertyValue.ToString();
        //}
    }
}

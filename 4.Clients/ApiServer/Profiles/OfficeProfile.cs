using ApiServer.Contracts.Office;
using Domain.Services.Contracts.Office;
using System.Collections.Generic;
using System.Collections;
using AutoMapper;
using ApiServer.Profiles;

namespace ApiServer.Profiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<CreateOfficeViewModel, CreateOfficeContract>();
            CreateMap<CreatedOfficeContract, CreatedOfficeViewModel>();
            CreateMap<ReadedOfficeContract, ReadedOfficeViewModel>();
            CreateMap<UpdateOfficeViewModel, UpdateOfficeContract>();
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

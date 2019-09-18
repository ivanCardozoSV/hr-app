using ApiServer.Contracts.Seed;
using AutoMapper;
using Domain.Services.Contracts.Seed;
using System.Collections;
using System.Collections.Generic;

namespace ApiServer.Profiles
{
    public class SeedProfile : Profile
    {
        public SeedProfile()
        {
            CreateMap<CreateDummyViewModel, CreateDummyViewModel> ();
            CreateMap<CreatedDummyContract, CreatedDummyViewModel>();
            CreateMap<ReadedDummyContract, ReadedDummyViewModel>();
            CreateMap<UpdateDummyViewModel, UpdateDummyContract>();
        }

        private static string ConverToString(System.Type propertyType, object propertyValue)
        {
            var enumPropery = propertyValue as IEnumerable;
            if (enumPropery != null && propertyType != typeof(string))
            {
                var stringValues = new List<string>();
                foreach (var item in enumPropery)
                {
                    stringValues.Add(item.ToString());
                }
                return string.Join(",", stringValues);
            }
            return propertyValue.ToString();
        }
    }
}

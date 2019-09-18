using ApiServer.Contracts.HireProjection;
using AutoMapper;
using Domain.Services.Contracts.HireProjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Profiles
{
    public class HireProjectionProfile : Profile
    {
        public HireProjectionProfile()
        {
            CreateMap<CreateHireProjectionViewModel, CreateHireProjectionContract>();
            CreateMap<CreatedHireProjectionContract, CreatedHireProjectionViewModel>();
            CreateMap<ReadedHireProjectionContract, ReadedHireProjectionViewModel>();
            CreateMap<UpdateHireProjectionViewModel, UpdateHireProjectionContract>();
        }

        private static string ConverToString(System.Type propertyType, object propertyValue)
        {
            var enumProperty = propertyValue as IEnumerable;
            if (enumProperty != null && propertyType != typeof(string))
            {
                var stringValues = new List<string>();
                foreach (var item in enumProperty)
                {
                    stringValues.Add(item.ToString());
                }
                return string.Join(",", stringValues);
            }
            return propertyValue.ToString();
        }
    }
}
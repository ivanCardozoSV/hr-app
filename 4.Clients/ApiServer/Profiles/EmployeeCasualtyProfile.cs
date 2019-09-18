using ApiServer.Contracts.EmployeeCasualty;
using AutoMapper;
using Domain.Services.Contracts.EmployeeCasualty;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Profiles
{
    public class EmployeeCasualtyProfile : Profile
    {
        public EmployeeCasualtyProfile()
        {
            CreateMap<CreateEmployeeCasualtyViewModel, CreateEmployeeCasualtyContract>();
            CreateMap<CreatedEmployeeCasualtyContract, CreatedEmployeeCasualtyViewModel>();
            CreateMap<ReadedEmployeeCasualtyContract, ReadedEmployeeCasualtyViewModel>();
            CreateMap<UpdateEmployeeCasualtyViewModel, UpdateEmployeeCasualtyContract>();
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
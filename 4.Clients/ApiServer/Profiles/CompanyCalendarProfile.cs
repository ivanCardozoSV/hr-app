using ApiServer.Contracts.CompanyCalendar;
using AutoMapper;
using Domain.Services.Contracts.CompanyCalendar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Profiles
{
    public class CompanyCalendarProfile : Profile
    {
        public CompanyCalendarProfile()
        {
            CreateMap<CreateCompanyCalendarViewModel, CreateCompanyCalendarContract>();
            CreateMap<CreatedCompanyCalendarContract, CreatedCompanyCalendarViewModel>();
            CreateMap<ReadedCompanyCalendarContract, ReadedCompanyCalendarViewModel>();
            CreateMap<UpdateCompanyCalendarViewModel, UpdateCompanyCalendarContract>();
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

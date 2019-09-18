using AutoMapper;
using Domain.Services.Contracts.CompanyCalendar;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;


namespace Domain.Services.Impl.Profiles
{
    class CompanyCalendarProfile : Profile
    {
        public CompanyCalendarProfile()
        {
            CreateMap<CompanyCalendar, ReadedCompanyCalendarContract>();
            CreateMap<CreateCompanyCalendarContract, CompanyCalendar>();
            CreateMap<CompanyCalendar, CreatedCompanyCalendarContract>();
            CreateMap<UpdateCompanyCalendarContract, CompanyCalendar>();
        }
    }
}

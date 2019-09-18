using Domain.Services.Contracts.CompanyCalendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces.Services
{
    public interface ICompanyCalendarService
    {
        CreatedCompanyCalendarContract Create(CreateCompanyCalendarContract contract);
        ReadedCompanyCalendarContract Read(int id);
        void Update(UpdateCompanyCalendarContract contract);
        void Delete(int id);
        IEnumerable<ReadedCompanyCalendarContract> List();
    }
}

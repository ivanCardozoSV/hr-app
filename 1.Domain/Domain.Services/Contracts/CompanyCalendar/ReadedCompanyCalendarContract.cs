using Domain.Services.Contracts.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Contracts.CompanyCalendar
{
    public class ReadedCompanyCalendarContract
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }
    }
}

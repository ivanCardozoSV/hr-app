using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.CompanyCalendar
{
    public class CreateCompanyCalendarViewModel
    {

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

 
    }
}

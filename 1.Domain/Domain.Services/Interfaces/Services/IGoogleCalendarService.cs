using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces.Services
{
    public interface IGoogleCalendarService
    {
        string CreateEvent(Event newEvent);
        bool DeleteEvent(string googleCalendarEventId);
    }
}

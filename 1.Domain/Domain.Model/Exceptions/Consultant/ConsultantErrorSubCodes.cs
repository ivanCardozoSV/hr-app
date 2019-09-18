using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Consultant
{
    public enum ConsultantErrorSubCodes
    {
        InvalidUpdateStatus,
        DeleteConsultantNotFound,
        ConsultantDeleted,
        InvalidUpdate,
        UpdateConsultantNotFound,
        UpdateHasNotChanges,
        ConsultantNotFound
    }
}

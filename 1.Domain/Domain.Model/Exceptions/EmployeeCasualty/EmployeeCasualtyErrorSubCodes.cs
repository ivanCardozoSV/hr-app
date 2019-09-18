using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.EmployeeCasualty
{
    public enum EmployeeCasualtyErrorSubCodes
    {
        InvalidUpdateStatus,
        DeleteEmployeeCasualtyNotFound,
        EmployeeCasualtyDeleted,
        InvalidUpdate,
        UpdateEmployeeCasualtyNotFound,
        UpdateHasNotChanges,
        EmployeeCasualtyNotFound
    }
}

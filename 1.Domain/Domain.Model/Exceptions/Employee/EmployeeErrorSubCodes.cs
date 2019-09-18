using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Employee
{
    public enum EmployeeErrorSubCodes
    {
        InvalidUpdateStatus,
        DeleteEmployeeNotFound,
        EmployeeDeleted,
        InvalidUpdate,
        UpdateEmployeeNotFound,
        UpdateHasNotChanges,
        EmployeeNotFound
    }
}

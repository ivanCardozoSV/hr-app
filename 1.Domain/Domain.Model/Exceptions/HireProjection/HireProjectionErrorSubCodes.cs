using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.HireProjection
{
    public enum HireProjectionErrorSubCodes
    {
        InvalidUpdateStatus,
        DeleteHireProjectionNotFound,
        HireProjectionDeleted,
        InvalidUpdate,
        UpdateHireProjectionNotFound,
        UpdateHasNotChanges,
        HireProjectionNotFound
    }
}

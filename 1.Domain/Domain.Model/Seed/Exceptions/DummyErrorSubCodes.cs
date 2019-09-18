using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Seed.Exceptions
{
    public enum DummyErrorSubCodes
    {
        InvalidUpdateStatus,
        DeleteDummyNotFound,
        DummyDeleted,
        InvalidUpdate,
        UpdateDummyNotFound,
        UpdateHasNotChanges,
        DummyNotFound
    }
}

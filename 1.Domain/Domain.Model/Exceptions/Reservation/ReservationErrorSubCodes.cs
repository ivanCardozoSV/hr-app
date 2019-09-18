using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Reservation
{
    public enum ReservationErrorSubCodes
    {
        InvalidUpdateStatus,
        DeleteReservationNotFound,
        ReservationDeleted,
        InvalidUpdate,
        UpdateReservationNotFound,
        UpdateHasNotChanges,
        ReservationNotFound
    }
}

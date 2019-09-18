using System;
using System.Collections.Generic;
using Domain.Services.Contracts.Reservation;
using Domain.Services.Contracts.Office;

namespace Domain.Services.Contracts.Room
{
    public class CreateRoomContract
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OfficeId { get; set; }
        public CreateOfficeContract Office { get; set; }
        public ICollection<CreateReservationContract> ReservationItems { get; set; }
    }
}

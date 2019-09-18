using System;
using System.Collections.Generic;
using System.Text;
using Domain.Services.Contracts.Reservation;
using Domain.Services.Contracts.Office;

namespace Domain.Services.Contracts.Room
{
    public class ReadedRoomContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OfficeId { get; set; }
        public ReadedOfficeContract Office { get; set; }
        public ICollection<ReadedReservationContract> ReservationItems { get; set; }
    }
}

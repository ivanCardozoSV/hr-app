using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Contracts.Reservation;
using ApiServer.Contracts.Office;

namespace ApiServer.Contracts.Room
{
    public class ReadedRoomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OfficeId { get; set; }
        public ReadedOfficeViewModel Office { get; set; }
        public ICollection<ReadedReservationViewModel> ReservationItems { get; set; }
    }
}

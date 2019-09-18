using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Contracts.Reservation;
using ApiServer.Contracts.Office;

namespace ApiServer.Contracts.Room
{
    public class UpdateRoomViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OfficeId { get; set; }
        public UpdateOfficeViewModel Office { get; set; }
        public ICollection<CreateReservationViewModel> ReservationItems { get; set; }
    }
}

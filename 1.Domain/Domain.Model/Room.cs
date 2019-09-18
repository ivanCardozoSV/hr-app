using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Room : DescriptiveEntity<int>
    {
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public IList<Reservation> ReservationItems { get; set; }

    }
}

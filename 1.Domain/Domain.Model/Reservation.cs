using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Reservation : Entity<int>
    {

        public string Description { get; set; }
        public DateTime SinceReservation { get; set; }
        public DateTime UntilReservation { get; set; }
        public Consultant Recruiter { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}

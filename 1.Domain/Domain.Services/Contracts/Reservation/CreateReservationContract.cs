﻿using System;
using System.Collections.Generic;
using Domain.Services.Contracts.Room;

namespace Domain.Services.Contracts.Reservation
{
    public class CreateReservationContract
    {
        public string Description { get; set; }
        public DateTime SinceReservation { get; set; } 
        public DateTime UntilReservation { get; set; }
        //public TimeSpan Time { get; set; }
        public int Recruiter { get; set; }
        public int RoomId { get; set; }
        public CreateRoomContract Room { get; set; }
    }
}

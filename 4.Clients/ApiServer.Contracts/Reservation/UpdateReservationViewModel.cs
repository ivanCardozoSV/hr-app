using ApiServer.Contracts.Consultant;
using ApiServer.Contracts.TaskItem;
using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Contracts.Room;

namespace ApiServer.Contracts.Reservation
{
    public class UpdateReservationViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime SinceReservation { get; set; }
        public DateTime UntilReservation { get; set; }
        //public TimeSpan Time { get; set; }
        public int Recruiter { get; set; }
        public int RoomId { get; set; }
        public UpdateRoomViewModel Room { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Domain.Services.Contracts.Room;

namespace Domain.Services.Contracts.Office
{
    public class CreateOfficeContract
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CreateRoomContract> RoomItems { get; set; }
    }
}

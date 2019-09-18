using System;
using System.Collections.Generic;
using System.Text;
using Domain.Services.Contracts.Room;

namespace Domain.Services.Contracts.Office
{
    public class UpdateOfficeContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CreateRoomContract> RoomItems { get; set; }
    }
}

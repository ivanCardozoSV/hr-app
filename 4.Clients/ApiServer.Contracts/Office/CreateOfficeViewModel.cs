using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Contracts.Room;

namespace ApiServer.Contracts.Office
{
    public class CreateOfficeViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CreateRoomViewModel> RoomItems { get; set; }
    }
}

using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Office : DescriptiveEntity<int>
    {
        public IList<Room> RoomItems { get; set; }

    }
}

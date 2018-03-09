using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnBooking.Models
{
    public class Rooms
    {
        public int RoomNumber { get; set; }
        public int RoomCapacity { get; set; }
        public int LuggageCount { get; set; }

        public Rooms(int RoomNumber, int RoomCapacity, int LuggageCount)
        {
            this.RoomNumber = RoomNumber;
            this.RoomCapacity = RoomCapacity;
            this.LuggageCount = LuggageCount;
        }

        public Rooms()
        {
        }
    }  
}

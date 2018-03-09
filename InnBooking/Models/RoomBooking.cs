using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnBooking.Models
{
    public class RoomBooking
    {
        public int BookingId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public int NumberofPPl { get; set; }
        public int LuggageCount { get; set; }

        public RoomBooking(int BookingId, int RoomNumber, DateTime CheckinTime, DateTime CheckoutTime, int NumberOfPPl, int LuggageCount)
        {
            this.RoomNumber = RoomNumber;
            this.CheckinTime = CheckinTime;
            this.CheckoutTime = CheckoutTime;
            this.NumberofPPl = NumberOfPPl;
            this.LuggageCount = LuggageCount;
        }
    }
}

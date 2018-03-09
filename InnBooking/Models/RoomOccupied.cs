using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnBooking.Models
{
    public class RoomOccupied
    {
        public int BookingId { get; set; }
        public DateTime CheckoutTime { get; set; }
        public int NumberofPpl { get; set; }
        public int RoomNumber { get; set; }
        public bool isCleaned { get; set; }

        public RoomOccupied(int BookingId, int RoomNumber, DateTime CheckoutTime, int NumberOfPPl)
        {
            this.RoomNumber = RoomNumber;
            this.CheckoutTime = CheckoutTime;
            this.NumberofPpl = NumberOfPPl;
            this.BookingId = BookingId;
            this.isCleaned = false;
        }
    }
}

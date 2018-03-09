using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnBooking.Models
{
    public class GnomeRoster
    {
        public int GnomeId { get; set; }
        public DateTime ShiftStartDate { get; set; }
        public int ShiftStartTime { get; set; } // written in 24 hour format
        public int MaxHoursWorking { get; set; }

        public GnomeRoster(int GnomeId, DateTime ShiftStartDate, int ShiftStartTime, int MaxHoursWorking)
        {
            this.GnomeId = GnomeId;
            this.ShiftStartDate = ShiftStartDate;
            this.ShiftStartTime = ShiftStartTime;
            this.MaxHoursWorking = MaxHoursWorking;
        }
    }

}

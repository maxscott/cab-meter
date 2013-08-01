using System;

namespace CabMeter.Models
{
    public class Trip
    {
        public int MinutesAbove6Mph { get; set; }
        public int MilesUnder6Mph { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public decimal TotalFare { get; set; }

        public DateTime StartDateTime 
        {
            get
            {
                return new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hour, StartTime.Minute, 0);
            }
            set
            {
                StartDate = new DateTime(value.Year, value.Month, value.Day);
                StartTime = new DateTime(1000, 1, 1, value.Hour, value.Minute, 0);
            }
        }
    }
}
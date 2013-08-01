using System;

namespace CabMeter.Models
{
    public class Trip
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }

        public int MinutesAbove6Mph { get; set; }
        public int MilesUnder6Mph { get; set; }
        public DateTime StartTime { get; set; }

        public decimal TotalFare { get; set; }
    }
}
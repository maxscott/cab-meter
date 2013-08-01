using System;
using CabMeter.Models;

namespace CabMeter.Calculation
{
    public class FareCalculator : IFareCalculator
    {
        public decimal CalculateFare(Trip t)
        {
            // inject a rule factory, and make each of these an IRule to iterate over maybe?
            t.TotalFare = 3m;
            t.TotalFare += NyTax;
            t.TotalFare += PeakCharge(t);
            t.TotalFare += NightCharge(t);
            t.TotalFare += MilesUnderSixMph(t);
            t.TotalFare += MinutesOverSix(t);

            return t.TotalFare;
        }

        public decimal NyTax { get { return .5m; } }

        public decimal PeakCharge(Trip trip)
        {
            var hour = trip.StartTime.Hour;
            if(IsWeekDay(trip.StartTime) && (hour > 16 && hour < 20))
            {
                return 1;
            }

            return 0;
        }

        public decimal MilesUnderSixMph(Trip trip)
        {
            return trip.MilesUnder6Mph * 5m *.35m;
        }

        public decimal MinutesOverSix(Trip trip)
        {
            return trip.MinutesAbove6Mph*.35m;
        }
        
        public decimal NightCharge(Trip trip)
        {
            return IsNight(trip.StartTime) ? .5m : 0;
        }

        static bool IsWeekDay(DateTime dateTime)
        {
            return (dateTime.DayOfWeek != DayOfWeek.Saturday &&
                    dateTime.DayOfWeek != DayOfWeek.Sunday);
        }

        static bool IsNight(DateTime dateTime)
        {
            return (dateTime.Hour > 20 || dateTime.Hour < 6);
        }
    }
}
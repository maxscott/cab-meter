using System;
using CabMeter.Models;

namespace CabMeter.Calculation.Rules
{
    public class PeakChargeRule : ICalculationRule
    {
        public decimal Calculate(Trip trip)
        {
            var hour = trip.StartTime.Hour;
            if(IsWeekDay(trip.StartTime) && (hour > 16 && hour < 20))
            {
                return 1;
            }

            return 0;
        }

        static bool IsWeekDay(DateTime dateTime)
        {
            return (dateTime.DayOfWeek != DayOfWeek.Saturday &&
                    dateTime.DayOfWeek != DayOfWeek.Sunday);
        }
    }
}
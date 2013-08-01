using System;
using CabMeter.Models;

namespace CabMeter.Calculation
{
    public class FareCalculator : IFareCalculator
    {
        public decimal CalculateFare(Trip t)
        {
            t.TotalFare = 3m;

            throw new System.NotImplementedException();
        }

        decimal NyTax { get { return .5m; } }
        decimal peakCharge(Trip trip)
        {
            if(IsWeekDay(trip.StartTime) && trip.StartTime.)
        }

        bool IsWeekDay(DateTime dateTime)
        {
            return (dateTime.DayOfWeek != DayOfWeek.Saturday &&
                    dateTime.DayOfWeek != DayOfWeek.Sunday);
        }
    }
}
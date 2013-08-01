using System;
using CabMeter.Models;

namespace CabMeter.Calculation
{
    public class NightChargeRule : ICalculationRule
    {
        public decimal Calculate(Trip trip)
        {
            return IsNight(trip.StartTime) ? .5m : 0;
        }

        static bool IsNight(DateTime dateTime)
        {
            return (dateTime.Hour > 20 || dateTime.Hour < 6);
        }
    }
}
using CabMeter.Models;

namespace CabMeter.Calculation.Rules
{
    public class MinutesOverSixMphRule : ICalculationRule
    {
        public decimal Calculate(Trip trip)
        {
            return trip.MinutesAbove6Mph*.35m;
        }
    }
}
using CabMeter.Models;

namespace CabMeter.Calculation
{
    public class MinutesOverSixMph : ICalculationRule
    {
        public decimal Calculate(Trip trip)
        {
            return trip.MinutesAbove6Mph*.35m;
        }
    }
}
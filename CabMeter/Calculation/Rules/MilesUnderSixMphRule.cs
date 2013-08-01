using CabMeter.Models;

namespace CabMeter.Calculation.Rules
{
    public class MilesUnderSixMphRule : ICalculationRule
    {
        public decimal Calculate(Trip trip)
        {
            return trip.MilesUnder6Mph * 5m *.35m;
        }
    }
}
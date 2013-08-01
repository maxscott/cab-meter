using CabMeter.Models;

namespace CabMeter.Calculation
{
    public class NyTaxRule : ICalculationRule
    {
        public decimal Calculate(Trip trip)
        {
            return .5m;
        }
    }
}
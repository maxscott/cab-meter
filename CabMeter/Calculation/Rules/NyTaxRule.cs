using CabMeter.Models;

namespace CabMeter.Calculation.Rules
{
    public class NyTaxRule : ICalculationRule
    {
        public decimal Calculate(Trip trip)
        {
            return .5m;
        }
    }
}
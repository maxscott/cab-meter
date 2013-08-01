using CabMeter.Models;

namespace CabMeter.Calculation
{
    public class InitialFeeRule : ICalculationRule
    {
        public decimal Calculate(Trip trip)
        {
            return 3m;
        }
    }
}
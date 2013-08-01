using CabMeter.Models;

namespace CabMeter.Calculation
{
    public interface ICalculationRule
    {
        decimal Calculate(Trip trip);
    }
}
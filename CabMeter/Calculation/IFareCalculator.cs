using CabMeter.Models;

namespace CabMeter.Calculation
{
    public interface IFareCalculator
    {
        decimal CalculateFare(Trip t);
    }
}
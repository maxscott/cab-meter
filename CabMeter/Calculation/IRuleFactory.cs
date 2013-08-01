using System.Collections.Generic;

namespace CabMeter.Calculation
{
    public interface IRuleFactory
    {
        IEnumerable<ICalculationRule> GetRules();
    }
}
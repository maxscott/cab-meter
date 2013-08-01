using System.Collections.Generic;
using CabMeter.Calculation.Rules;

namespace CabMeter.Calculation
{
    public class RuleFactory : IRuleFactory
    {
        public IEnumerable<ICalculationRule> GetRules()
        {
            return new ICalculationRule[]
                {
                    new NyTaxRule(), 
                    new InitialFeeRule(), 
                    new PeakChargeRule(), 
                    new NightChargeRule(),
                    new MinutesOverSixMphRule(), 
                    new MilesUnderSixMphRule()
                };
        }
    }
}
using CabMeter.Models;

namespace CabMeter.Calculation
{
    public class FareCalculator : IFareCalculator
    {
        private readonly IRuleFactory ruleFactory;

        public FareCalculator(IRuleFactory ruleFactory)
        {
            this.ruleFactory = ruleFactory;
        }

        public decimal CalculateFare(Trip trip)
        {
            trip.TotalFare = 0;

            foreach (var rule in ruleFactory.GetRules())
            {
                trip.TotalFare += rule.Calculate(trip);
            }

            return trip.TotalFare;
        }
    }
}
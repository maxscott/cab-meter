using System;
using CabMeter.Calculation;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Integration.Calculation
{
    [Subject(typeof(FareCalculator))]
    public class When_Calculating_a_fare : WithSubject<FareCalculator>
    {
        static decimal fare;
        static Trip trip = new Trip
        {
            StartTime = new DateTime(2010, 10, 8, 17, 30, 0),
            MilesUnder6Mph = 2,
            MinutesAbove6Mph = 5
        };

        Establish context = () => The<IRuleFactory>().WhenToldTo(f => f.GetRules()).Return(new RuleFactory().GetRules());
        Because of = () => fare = Subject.CalculateFare(trip);
        It should_make_value = () => fare.ShouldEqual(9.75m);
    }
}

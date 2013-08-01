using System;
using CabMeter.Calculation;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation
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
        Because of = () => fare = Subject.CalculateFare(trip);
        It should_make_value = () => fare.ShouldEqual(9.75m);
    }
}

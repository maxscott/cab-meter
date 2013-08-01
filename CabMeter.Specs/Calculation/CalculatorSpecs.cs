using System;
using System.Collections.Generic;
using CabMeter.Calculation;
using CabMeter.Calculation.Rules;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation
{
    [Subject(typeof (FareCalculator))]
    public class When_Calculating_a_fare : WithSubject<FareCalculator>
    {
        static decimal fare;
        static Trip trip = new Trip();

        static IEnumerable<ICalculationRule> sampleRules = 
            new List<ICalculationRule> {
                new InitialFeeRule(), 
                new NyTaxRule()}; 

        Establish context = () => The<IRuleFactory>().WhenToldTo(f => f.GetRules()).Return(sampleRules);
        Because of = () => fare = Subject.CalculateFare(trip);

        It should_call_GetRules = () => The<IRuleFactory>().WasToldTo(f => f.GetRules());
        It should_make_value_350_cents = () => fare.ShouldEqual(3.50m);
    }

    [Subject(typeof(FareCalculator))]
    public class When_Calculating_a_fare_twice : WithSubject<FareCalculator>
    {
        static decimal fare;
        static decimal fare2;
        static Trip trip = new Trip();

        static IEnumerable<ICalculationRule> sampleRules =
            new List<ICalculationRule> {
                new InitialFeeRule(), 
                new NyTaxRule()};

        Establish context = () => The<IRuleFactory>().WhenToldTo(f => f.GetRules()).Return(sampleRules);
        Because of = () =>
            {
                fare = Subject.CalculateFare(trip);
                fare2 = Subject.CalculateFare(trip);
            };

        It should_reset_the_trips_fare = () => fare.ShouldEqual(fare2);
    }
}

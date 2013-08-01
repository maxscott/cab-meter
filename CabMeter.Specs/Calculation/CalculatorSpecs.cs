using System;
using CabMeter.Calculation;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation
{
    [Subject(typeof(InitialFeeRule))]
    public class When_Getting_Inital_Fee : WithSubject<InitialFeeRule>
    {
        It should_return_3 = () => Subject.Calculate(new Trip()).ShouldEqual(3m);
    }

    [Subject(typeof (NyTaxRule))]
    public class When_NY_Tax : WithSubject<NyTaxRule>
    {
        It should_return_50_cents = () => Subject.Calculate(new Trip()).ShouldEqual(.5m);
    }

    [Subject(typeof(PeakChargeRule))]
    public class When_Calculating_Peak_Charge : WithSubject<PeakChargeRule>
    {
        It should_return_1 = () => Subject.Calculate(new Trip { StartTime = new DateTime(2010, 1, 1, 17, 30, 0) }).ShouldEqual(1);
        It should_return_0 = () => Subject.Calculate(new Trip { StartTime = new DateTime(2010, 1, 1, 21, 30, 0) }).ShouldEqual(0);
    }

    [Subject(typeof(NightChargeRule))]
    public class When_Calculating_Night_Surcharge : WithSubject<NightChargeRule>
    {
        It should_return_50_cents_at_night = () => Subject.Calculate(new Trip { StartTime = new DateTime(2010, 1, 1, 21, 30, 0) }).ShouldEqual(.5m);
        It should_return_0_during_the_day = () => Subject.Calculate(new Trip { StartTime = new DateTime(2010, 1, 1, 7, 30, 0) }).ShouldEqual(0);
    }

    [Subject(typeof(MilesUnderSixMphRule))]
    public class When_Calculating_Mile_Charge_Under_6_Mph : WithSubject<MilesUnderSixMphRule>
    {
        It should_return_350_cents_for_2_miles = () => Subject.Calculate(new Trip { MilesUnder6Mph = 2}).ShouldEqual(3.50m);
    }

    [Subject(typeof(MinutesOverSixMph))]
    public class When_Calculating_Minute_Charge_OVer_6_Mph : WithSubject<MinutesOverSixMph>
    {
        It should_return_175_cents_for_5_minutes = () => Subject.Calculate(new Trip { MinutesAbove6Mph = 5 }).ShouldEqual(1.75m);
    }

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

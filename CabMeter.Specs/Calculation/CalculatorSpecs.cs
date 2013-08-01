using System;
using CabMeter.Calculation;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation
{
    [Subject(typeof (FareCalculator))]
    public class When_NY_Tax : WithSubject<FareCalculator>
    {
        It should_return_50_cents = () => Subject.NyTax.ShouldEqual(.5m);
    }

    [Subject(typeof(FareCalculator))]
    public class When_Calculating_Peak_Charge : WithSubject<FareCalculator>
    {
        It should_return_1 = () => Subject.PeakCharge(new Trip { StartTime = new DateTime(2010, 1, 1, 17, 30, 0) }).ShouldEqual(1);
        It should_return_0 = () => Subject.PeakCharge(new Trip { StartTime = new DateTime(2010, 1, 1, 21, 30, 0) }).ShouldEqual(0);
    }

    [Subject(typeof(FareCalculator))]
    public class When_Calculating_Night_Surcharge : WithSubject<FareCalculator>
    {
        It should_return_50_cents_at_night = () => Subject.NightCharge(new Trip { StartTime = new DateTime(2010, 1, 1, 21, 30, 0) }).ShouldEqual(.5m);
        It should_return_0_during_the_day = () => Subject.NightCharge(new Trip { StartTime = new DateTime(2010, 1, 1, 7, 30, 0) }).ShouldEqual(0);
    }

    [Subject(typeof(FareCalculator))]
    public class When_Calculating_Mile_Charge_Under_6_Mph : WithSubject<FareCalculator>
    {
        It should_return_350_cents_for_2_miles = () => Subject.MilesUnderSixMph(new Trip { MilesUnder6Mph = 2}).ShouldEqual(3.50m);
    }

    [Subject(typeof(FareCalculator))]
    public class When_Calculating_Minute_Charge_OVer_6_Mph : WithSubject<FareCalculator>
    {
        It should_return_175_cents_for_5_minutes = () => Subject.MinutesOverSix(new Trip { MinutesAbove6Mph = 5 }).ShouldEqual(1.75m);
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

        Because of = () => fare = Subject.CalculateFare(trip);
        It should_make_value = () => fare.ShouldEqual(9.75m);
    }
}

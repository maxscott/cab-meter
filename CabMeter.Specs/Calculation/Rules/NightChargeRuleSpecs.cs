using System;
using CabMeter.Calculation.Rules;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation.Rules
{
    [Subject(typeof(NightChargeRule))]
    public class When_Calculating_Night_Surcharge : WithSubject<NightChargeRule>
    {
        It should_return_50_cents_at_night = () => Subject.Calculate(new Trip { StartDateTime = new DateTime(2010, 1, 1, 21, 30, 0) }).ShouldEqual(.5m);
        It should_return_0_during_the_day = () => Subject.Calculate(new Trip { StartDateTime = new DateTime(2010, 1, 1, 7, 30, 0) }).ShouldEqual(0);
    }
}

using System;
using CabMeter.Calculation.Rules;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation.Rules
{
    [Subject(typeof(PeakChargeRule))]
    public class When_Calculating_Peak_Charge : WithSubject<PeakChargeRule>
    {
        It should_return_1 = () => Subject.Calculate(new Trip { StartDateTime = new DateTime(2010, 1, 1, 17, 30, 0) }).ShouldEqual(1);
        It should_return_0 = () => Subject.Calculate(new Trip { StartDateTime = new DateTime(2010, 1, 1, 21, 30, 0) }).ShouldEqual(0);
    }
}

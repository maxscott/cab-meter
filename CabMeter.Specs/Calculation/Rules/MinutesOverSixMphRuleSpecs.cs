using CabMeter.Calculation.Rules;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation.Rules
{
    [Subject(typeof(MinutesOverSixMphRule))]
    public class When_Calculating_Minute_Charge_OVer_6_Mph : WithSubject<MinutesOverSixMphRule>
    {
        It should_return_175_cents_for_5_minutes = () => Subject.Calculate(new Trip { MinutesAbove6Mph = 5 }).ShouldEqual(1.75m);
    }
}

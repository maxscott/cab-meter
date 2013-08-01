using CabMeter.Calculation.Rules;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation.Rules
{
    [Subject(typeof(MilesUnderSixMphRule))]
    public class When_Calculating_Mile_Charge_Under_6_Mph : WithSubject<MilesUnderSixMphRule>
    {
        It should_return_350_cents_for_2_miles = () => Subject.Calculate(new Trip { MilesUnder6Mph = 2 }).ShouldEqual(3.50m);
    }
}

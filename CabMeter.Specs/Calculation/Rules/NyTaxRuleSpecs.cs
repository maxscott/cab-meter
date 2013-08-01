using CabMeter.Calculation.Rules;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation.Rules
{
    [Subject(typeof(NyTaxRule))]
    public class When_NY_Tax : WithSubject<NyTaxRule>
    {
        It should_return_50_cents = () => Subject.Calculate(new Trip()).ShouldEqual(.5m);
    }
}

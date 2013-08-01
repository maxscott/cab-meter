using CabMeter.Calculation.Rules;
using CabMeter.Models;
using Machine.Fakes;
using Machine.Specifications;

namespace CabMeter.Specs.Calculation.Rules
{
    [Subject(typeof(InitialFeeRule))]
    public class When_Getting_Inital_Fee : WithSubject<InitialFeeRule>
    {
        It should_return_3 = () => Subject.Calculate(new Trip()).ShouldEqual(3m);
    }
}

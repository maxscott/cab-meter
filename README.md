Cab Meter
============

Describes and executes the rules for determining the cost of a cab ride given some inputs. Relatively SOLID.


The Ember [app](/CabMeter/Scripts/app) has no logic/tests/validations, just model, template, binding. The [TripsController](/CabMeter/Controllers/TripsController.cs)'s GET calculates the trip's cost and returns it in the response. It uses the [FareCalculator](/CabMeter/Calculation/FareCalculator.cs) with [tests](/CabMeter.Specs/Calculation/CalculatorSpecs.cs) which uses the [ICalculationRules](/CabMeter/Calculation/Rules) with [tests](/CabMeter.Specs/Calculation/Rules). Lastly, this particular [RuleFactory](/CabMeter/Calculation/RuleFactory.cs) is integration tested [here](CabMeter.Integration/Calculation/CalculatorIntegration.cs).

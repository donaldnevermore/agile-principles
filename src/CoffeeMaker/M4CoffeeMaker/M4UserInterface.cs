using AgilePrinciples.CoffeeMaker.Domain;

namespace AgilePrinciples.CoffeeMaker.M4CoffeeMaker;

using AgilePrinciples.CoffeeMaker.Domain;

public class M4UserInterface : UserInterface, Pollable {
    private readonly CoffeeMakerApi api;

    public M4UserInterface(CoffeeMakerApi api) {
        this.api = api;
    }

    public void Poll() {
        var buttonStatus = api.GetBrewButtonStatus();

        if (buttonStatus == BrewButtonStatus.Pushed) {
            StartBrewing();
        }
    }

    public override void Done() {
        api.SetIndicatorState(IndicatorState.On);
    }

    public override void CompleteCycle() {
        api.SetIndicatorState(IndicatorState.Off);
    }
}

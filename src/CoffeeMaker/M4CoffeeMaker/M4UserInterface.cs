using AgileSoftwareDevelopment.CoffeeMaker.Domain;

namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker {
    public class M4UserInterface : UserInterface, Pollable {
        private readonly CoffeeMakerAPI api;

        public M4UserInterface(CoffeeMakerAPI api) {
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
}

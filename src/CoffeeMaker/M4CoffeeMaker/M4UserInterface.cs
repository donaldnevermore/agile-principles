using AgileSoftwareDevelopment.CoffeeMaker.Domain;

namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker {
    public class M4UserInterface : UserInterface, Pollable {
        private CoffeeMakerApi api;

        public M4UserInterface(CoffeeMakerApi api) {
            this.api = api;
        }

        public void Poll() {
            BrewButtonStatus buttonStatus = api.GetBrewButtonStatus();

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

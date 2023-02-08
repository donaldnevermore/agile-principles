using AgileSoftwareDevelopment.CoffeeMaker.Domain;

namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker {
    public class M4HotWaterSource : HotWaterSource, Pollable {
        private readonly CoffeeMakerApi api;

        public M4HotWaterSource(CoffeeMakerApi api) {
            this.api = api;
        }

        public override bool IsReady() {
            var boilerStatus = api.GetBoilerStatus();
            return boilerStatus == BoilerStatus.NotEmpty;
        }

        public override void StartBrewing() {
            api.SetReliefValveState(ReliefValveState.Closed);
            api.SetBoilerState(BoilerState.On);
        }

        public void Poll() {
            var boilerStatus = api.GetBoilerStatus();

            if (isBrewing) {
                if (boilerStatus == BoilerStatus.Empty) {
                    api.SetBoilerState(BoilerState.Off);
                    api.SetReliefValveState(ReliefValveState.Closed);
                    DeclareDone();
                }
            }
        }

        public override void Pause() {
            api.SetBoilerState(BoilerState.Off);
            api.SetReliefValveState(ReliefValveState.Open);
        }

        public override void Resume() {
            api.SetBoilerState(BoilerState.On);
            api.SetReliefValveState(ReliefValveState.Closed);
        }
    }
}

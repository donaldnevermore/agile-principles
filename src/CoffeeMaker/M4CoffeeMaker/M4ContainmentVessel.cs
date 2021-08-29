using AgileSoftwareDevelopment.CoffeeMaker.Domain;

namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker {
    public class M4ContainmentVessel : ContainmentVessel, Pollable {
        private readonly CoffeeMakerAPI api;
        private WarmerPlateStatus lastPotStatus;

        public M4ContainmentVessel(CoffeeMakerAPI api) {
            this.api = api;
            lastPotStatus = WarmerPlateStatus.PotEmpty;
        }

        public override bool IsReady() {
            var plateStatus = api.GetWarmerPlateStatus();
            return plateStatus == WarmerPlateStatus.PotEmpty;
        }

        public void Poll() {
            var potStatus = api.GetWarmerPlateStatus();

            if (potStatus != lastPotStatus) {
                if (isBrewing) {
                    HandleBrewingEvent(potStatus);
                }
                else if (isComplete == false) {
                    HandleIncompleteEvent(potStatus);
                }
            }

            lastPotStatus = potStatus;
        }

        private void HandleBrewingEvent(WarmerPlateStatus potStatus) {
            if (potStatus == WarmerPlateStatus.PotNotEmpty) {
                ContainerAvailable();
                api.SetWarmerState(WarmerState.On);
            }
            else if (potStatus == WarmerPlateStatus.WarmerEmpty) {
                ContainerUnavailable();
                api.SetWarmerState(WarmerState.Off);
            }
            else {
                // potStatus == PotEmpty
                ContainerAvailable();
                api.SetWarmerState(WarmerState.Off);
            }
        }

        private void HandleIncompleteEvent(WarmerPlateStatus potStatus) {
            if (potStatus == WarmerPlateStatus.PotNotEmpty) {
                api.SetWarmerState(WarmerState.On);
            }
            else if (potStatus == WarmerPlateStatus.WarmerEmpty) {
                api.SetWarmerState(WarmerState.Off);
            }
            else {
                // potStatus == PotEmpty
                api.SetWarmerState(WarmerState.Off);
                DeclareComplete();
            }
        }
    }
}

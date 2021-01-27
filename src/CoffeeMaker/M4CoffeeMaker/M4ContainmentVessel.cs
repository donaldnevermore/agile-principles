using AgileSoftwareDevelopment.CoffeeMaker.Domain;

namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker {
    public class M4ContainmentVessel : ContainmentVessel, Pollable {
        private CoffeeMakerApi api;
        private WarmerPlateStatus lastPotStatus;

        public M4ContainmentVessel(CoffeeMakerApi api) {
            this.api = api;
            lastPotStatus = WarmerPlateStatus.PotEmpty;
        }

        public override bool IsReady() {
            WarmerPlateStatus plateStatus = api.GetWarmerPlateStatus();
            return plateStatus == WarmerPlateStatus.PotEmpty;
        }

        public void Poll() {
            WarmerPlateStatus potStatus = api.GetWarmerPlateStatus();

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
                // potStatus == POT_EMPTY
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
                // potStatus == POT_EMPTY
                api.SetWarmerState(WarmerState.Off);
                DeclareComplete();
            }
        }
    }
}

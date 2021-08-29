using AgileSoftwareDevelopment.CoffeeMaker.Domain;

namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker {
    internal class CoffeeMakerStub : CoffeeMakerAPI {
        public bool ButtonPressed { get; set; } = false;
        public bool LightOn { get; set; } = false;
        public bool BoilerOn { get; set; } = false;
        public bool ValveClosed { get; set; } = true;
        public bool PlateOn { get; set; } = false;
        public bool BoilerEmpty { get; set; } = true;
        public bool PotPresent { get; set; } = true;
        public bool PotNotEmpty { get; set; } = false;

        public WarmerPlateStatus GetWarmerPlateStatus() {
            if (!PotPresent) {
                return WarmerPlateStatus.WarmerEmpty;
            }
            else if (PotNotEmpty) {
                return WarmerPlateStatus.PotNotEmpty;
            }
            else {
                return WarmerPlateStatus.PotEmpty;
            }
        }

        public BoilerStatus GetBoilerStatus() {
            return BoilerEmpty ? BoilerStatus.Empty : BoilerStatus.NotEmpty;
        }

        public BrewButtonStatus GetBrewButtonStatus() {
            if (ButtonPressed) {
                ButtonPressed = false;
                return BrewButtonStatus.Pushed;
            }
            else {
                return BrewButtonStatus.NotPushed;
            }
        }

        public void SetBoilerState(BoilerState boilerState) {
            BoilerOn = boilerState == BoilerState.On;
        }

        public void SetWarmerState(WarmerState warmerState) {
            PlateOn = warmerState == WarmerState.On;
        }

        public void SetIndicatorState(IndicatorState indicatorState) {
            LightOn = indicatorState == IndicatorState.On;
        }

        public void SetReliefValveState(ReliefValveState reliefValveState) {
            ValveClosed = reliefValveState == ReliefValveState.Closed;
        }
    }
}

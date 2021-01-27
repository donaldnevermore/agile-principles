using AgileSoftwareDevelopment.CoffeeMaker.Domain;
using NUnit.Framework;

namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker {
    internal class CoffeeMakerStub : CoffeeMakerApi {
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

    [TestFixture]
    public class M4CoffeeMakerTest {
        private CoffeeMakerStub api;
        private M4UserInterface ui;
        private M4HotWaterSource hws;
        private M4ContainmentVessel cv;

        [SetUp]
        public void SetUp() {
            api = new CoffeeMakerStub();
            ui = new M4UserInterface(api);
            hws = new M4HotWaterSource(api);
            cv = new M4ContainmentVessel(api);

            ui.Init(hws, cv);
            hws.Init(ui, cv);
            cv.Init(ui, hws);
        }

        private void Poll() {
            ui.Poll();
            hws.Poll();
            cv.Poll();
        }

        [Test]
        public void InitialConditions() {
            Poll();
            Assert.IsFalse(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        [Test]
        public void StartNoPot() {
            Poll();
            api.ButtonPressed = true;
            api.PotPresent = false;
            Poll();
            Assert.IsFalse(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        [Test]
        public void StartNoWater() {
            Poll();
            api.ButtonPressed = true;
            api.BoilerEmpty = true;
            Poll();
            Assert.IsFalse(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        [Test]
        public void GoodStart() {
            NormalStart();
            Assert.IsTrue(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        private void NormalStart() {
            Poll();
            api.BoilerEmpty = false;
            api.ButtonPressed = true;
            Poll();
        }

        [Test]
        public void StartedPotNotEmpty() {
            NormalStart();
            api.PotNotEmpty = true;
            Poll();
            Assert.IsTrue(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsTrue(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        [Test]
        public void PotRemovedAndReplacedWhileEmpty() {
            NormalStart();
            api.PotPresent = false;
            Poll();

            Assert.IsFalse(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsFalse(api.ValveClosed);

            api.PotPresent = true;
            Poll();
            Assert.IsTrue(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedEmpty() {
            NormalFill();
            api.PotPresent = false;
            Poll();
            Assert.IsFalse(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsFalse(api.ValveClosed);

            api.PotPresent = true;
            api.PotNotEmpty = false;
            Poll();
            Assert.IsTrue(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        private void NormalFill() {
            NormalStart();
            api.PotNotEmpty = true;
            Poll();
        }

        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedNotEmpty() {
            NormalFill();
            api.PotPresent = false;
            Poll();
            api.PotPresent = true;
            Poll();
            Assert.IsTrue(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsTrue(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        [Test]
        public void BoilerEmptyPotNotEmpty() {
            NormalBrew();
            Assert.IsFalse(api.BoilerOn);
            Assert.IsTrue(api.LightOn);
            Assert.IsTrue(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        private void NormalBrew() {
            NormalFill();
            api.BoilerEmpty = true;
            Poll();
        }

        [Test]
        public void BoilerEmptiesWhilePotRemoved() {
            NormalFill();
            api.PotPresent = false;
            Poll();
            api.BoilerEmpty = true;
            Poll();
            Assert.IsFalse(api.BoilerOn);
            Assert.IsTrue(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);

            api.PotPresent = true;
            Poll();
            Assert.IsFalse(api.BoilerOn);
            Assert.IsTrue(api.LightOn);
            Assert.IsTrue(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }

        [Test]
        public void EmptyPotReturnedAfter() {
            NormalBrew();
            api.PotNotEmpty = false;
            Poll();
            Assert.IsFalse(api.BoilerOn);
            Assert.IsFalse(api.LightOn);
            Assert.IsFalse(api.PlateOn);
            Assert.IsTrue(api.ValveClosed);
        }
    }
}

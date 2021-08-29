namespace AgileSoftwareDevelopment.CoffeeMaker.Domain {
    public interface CoffeeMakerAPI {
        WarmerPlateStatus GetWarmerPlateStatus();

        BoilerStatus GetBoilerStatus();

        BrewButtonStatus GetBrewButtonStatus();

        void SetBoilerState(BoilerState state);

        void SetWarmerState(WarmerState state);

        void SetIndicatorState(IndicatorState state);

        void SetReliefValveState(ReliefValveState state);
    }
}

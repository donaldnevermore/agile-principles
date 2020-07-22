namespace AgileSoftwareDevelopment.CoffeeMaker
{
    public enum WarmerPlateStatus
    {
        WARMER_EMPTY,
        POT_EMPTY,
        POT_NOT_EMPTY
    }

    public enum BoilerStatus
    {
        EMPTY,
        NOT_EMPTY
    }


    public enum BrewButtonStatus
    {
        PUSHED,
        NOT_PUSHED
    }


    public enum BoilerState
    {
        ON,
        OFF
    }


    public enum WarmerState
    {
        ON,
        OFF
    }


    public enum IndicatorState
    {
        ON,
        OFF
    }


    public enum ReliefValveState
    {
        OPEN,
        CLOSED
    }


    public interface CoffeeMakerAPI
    {
        WarmerPlateStatus GetWarmerPlateStatus();

        BoilerStatus GetBoilerStatus();

        BrewButtonStatus GetBrewButtonStatus();

        void SetBoilerState(BoilerState s);

        void SetWarmerState(WarmerState s);

        void SetIndicatorState(IndicatorState s);

        void SetReliefValveState(ReliefValveState s);
    }
}

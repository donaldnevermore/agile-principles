namespace AgilePrinciples.CoffeeMaker.Domain;

public interface CoffeeMakerApi {
    WarmerPlateStatus GetWarmerPlateStatus();

    BoilerStatus GetBoilerStatus();

    BrewButtonStatus GetBrewButtonStatus();

    void SetBoilerState(BoilerState state);

    void SetWarmerState(WarmerState state);

    void SetIndicatorState(IndicatorState state);

    void SetReliefValveState(ReliefValveState state);
}

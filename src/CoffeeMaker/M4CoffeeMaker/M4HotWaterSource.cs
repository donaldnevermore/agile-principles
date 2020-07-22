namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker
{
    public class M4HotWaterSource : HotWaterSource, Pollable
    {
        private CoffeeMakerAPI api;

        public M4HotWaterSource(CoffeeMakerAPI api)
        {
            this.api = api;
        }

        public override bool IsReady()
        {
            BoilerStatus boilerStatus = api.GetBoilerStatus();
            return boilerStatus == BoilerStatus.NOT_EMPTY;
        }

        public override void StartBrewing()
        {
            api.SetReliefValveState(ReliefValveState.CLOSED);
            api.SetBoilerState(BoilerState.ON);
        }

        public void Poll()
        {
            BoilerStatus boilerStatus = api.GetBoilerStatus();

            if (isBrewing)
            {
                if (boilerStatus == BoilerStatus.EMPTY)
                {
                    api.SetBoilerState(BoilerState.OFF);
                    api.SetReliefValveState(ReliefValveState.CLOSED);
                    DeclareDone();
                }
            }
        }

        public override void Pause()
        {
            api.SetBoilerState(BoilerState.OFF);
            api.SetReliefValveState(ReliefValveState.OPEN);
        }

        public override void Resume()
        {
            api.SetBoilerState(BoilerState.ON);
            api.SetReliefValveState(ReliefValveState.CLOSED);
        }
    }
}

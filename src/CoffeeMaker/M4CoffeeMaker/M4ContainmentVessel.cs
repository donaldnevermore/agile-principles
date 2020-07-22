namespace AgileSoftwareDevelopment.CoffeeMaker.M4CoffeeMaker
{
    public class M4ContainmentVessel : ContainmentVessel, Pollable
    {
        private CoffeeMakerAPI api;
        private WarmerPlateStatus lastPotStatus;

        public M4ContainmentVessel(CoffeeMakerAPI api)
        {
            this.api = api;
            lastPotStatus = WarmerPlateStatus.POT_EMPTY;
        }

        public override bool IsReady()
        {
            WarmerPlateStatus plateStatus = api.GetWarmerPlateStatus();
            return plateStatus == WarmerPlateStatus.POT_EMPTY;
        }

        public void Poll()
        {
            WarmerPlateStatus potStatus = api.GetWarmerPlateStatus();

            if (potStatus != lastPotStatus)
            {
                if (isBrewing)
                {
                    HandleBrewingEvent(potStatus);
                }
                else if (isComplete == false)
                {
                    HandleIncompleteEvent(potStatus);
                }
            }

            lastPotStatus = potStatus;
        }

        private void HandleBrewingEvent(WarmerPlateStatus potStatus)
        {
            if (potStatus == WarmerPlateStatus.POT_NOT_EMPTY)
            {
                ContainerAvailable();
                api.SetWarmerState(WarmerState.ON);
            }
            else if (potStatus == WarmerPlateStatus.WARMER_EMPTY)
            {
                ContainerUnavailable();
                api.SetWarmerState(WarmerState.OFF);
            }
            else
            {
                // potStatus == POT_EMPTY
                ContainerAvailable();
                api.SetWarmerState(WarmerState.OFF);
            }
        }

        private void HandleIncompleteEvent(WarmerPlateStatus potStatus)
        {
            if (potStatus == WarmerPlateStatus.POT_NOT_EMPTY)
            {
                api.SetWarmerState(WarmerState.ON);
            }
            else if (potStatus == WarmerPlateStatus.WARMER_EMPTY)
            {
                api.SetWarmerState(WarmerState.OFF);
            }
            else
            {
                // potStatus == POT_EMPTY
                api.SetWarmerState(WarmerState.OFF);
                DeclareComplete();
            }
        }
    }
}

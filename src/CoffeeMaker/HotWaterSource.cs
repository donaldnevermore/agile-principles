namespace AgileSoftwareDevelopment.CoffeeMaker
{
    public abstract class HotWaterSource
    {
        private UserInterface ui;
        private ContainmentVessel cv;
        protected bool isBrewing;

        protected HotWaterSource()
        {
            isBrewing = false;
        }

        public void Init(UserInterface ui, ContainmentVessel cv)
        {
            this.ui = ui;
            this.cv = cv;
        }

        public void Start()
        {
            isBrewing = true;
            StartBrewing();
        }

        public void Done()
        {
            isBrewing = false;
        }

        protected void DeclareDone()
        {
            ui.Done();
            cv.Done();
            isBrewing = false;
        }

        public abstract bool IsReady();
        public abstract void StartBrewing();
        public abstract void Pause();
        public abstract void Resume();
    }
}

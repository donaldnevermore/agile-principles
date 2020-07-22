namespace AgileSoftwareDevelopment.CoffeeMaker
{
    public abstract class UserInterface
    {
        private HotWaterSource hws;
        private ContainmentVessel cv;
        protected bool isComplete;

        public UserInterface()
        {
            isComplete = true;
        }

        public void Init(HotWaterSource hws, ContainmentVessel cv)
        {
            this.hws = hws;
            this.cv = cv;
        }

        public void Complete()
        {
            isComplete = true;
            CompleteCycle();
        }

        protected void StartBrewing()
        {
            if (hws.IsReady() && cv.IsReady())
            {
                isComplete = false;
                hws.Start();
                cv.Start();
            }
        }

        public abstract void Done();
        public abstract void CompleteCycle();
    }
}

namespace AgileSoftwareDevelopment.CoffeeMaker.Domain;

public abstract class ContainmentVessel {
    protected bool isBrewing;
    protected bool isComplete;

    private UserInterface ui;
    private HotWaterSource hws;

    public void Init(UserInterface ui, HotWaterSource hws) {
        this.ui = ui;
        this.hws = hws;
    }

    public void Start() {
        isBrewing = true;
        isComplete = false;
    }

    public void Done() {
        isBrewing = false;
    }

    protected void DeclareComplete() {
        isComplete = true;
        ui.Complete();
    }

    protected void ContainerAvailable() {
        hws.Resume();
    }

    protected void ContainerUnavailable() {
        hws.Pause();
    }

    public abstract bool IsReady();
}

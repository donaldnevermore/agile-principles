namespace AgilePrinciples.CommandAndActiveObject;

public class SleepCommand : Command {
    private readonly Command wakeUpCommand = null;
    private readonly ActiveObjectEngine engine = null;
    private readonly long sleepTime = 0;
    private DateTime startTime;
    private bool started = false;

    public SleepCommand(long milliseconds, ActiveObjectEngine e, Command wakeUpCommand) {
        sleepTime = milliseconds;
        engine = e;
        this.wakeUpCommand = wakeUpCommand;
    }

    public void Execute() {
        var currentTime = DateTime.Now;
        if (!started) {
            started = true;
            startTime = currentTime;
            engine.AddCommand(this);
        } else {
            var elapsedTime = currentTime - startTime;
            if (elapsedTime.TotalMilliseconds < sleepTime) {
                engine.AddCommand(this);
            } else {
                engine.AddCommand(wakeUpCommand);
            }
        }
    }
}

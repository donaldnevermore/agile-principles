namespace AgileSoftwareDevelopment.CommandAndActiveObject;

public class DelayedTyper : Command {
    private readonly long itsDelay;
    private readonly char itsChar;
    private static bool stop = false;
    private static readonly ActiveObjectEngine engine = new();

    private class StopCommand : Command {
        public void Execute() {
            stop = true;
        }
    }

    public static void Start() {
        engine.AddCommand(new DelayedTyper(100, '1'));
        engine.AddCommand(new DelayedTyper(300, '3'));
        engine.AddCommand(new DelayedTyper(500, '5'));
        engine.AddCommand(new DelayedTyper(700, '7'));

        var stopCommand = new StopCommand();
        engine.AddCommand(new SleepCommand(20000, engine, stopCommand));
        engine.Run();
    }

    public DelayedTyper(long delay, char c) {
        itsDelay = delay;
        itsChar = c;
    }

    public void Execute() {
        Console.Write(itsChar);
        if (!stop) {
            DelayAndRepeat();
        }
    }

    private void DelayAndRepeat() {
        engine.AddCommand(new SleepCommand(itsDelay, engine, this));
    }
}

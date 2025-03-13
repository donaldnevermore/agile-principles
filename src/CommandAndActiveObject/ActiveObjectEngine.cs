namespace AgilePrinciples.CommandAndActiveObject;

public class ActiveObjectEngine {
    private readonly List<Command> itsCommands = new();

    public void AddCommand(Command c) {
        itsCommands.Add(c);
    }

    public void Run() {
        while (itsCommands.Count > 0) {
            var c = itsCommands[0];
            itsCommands.RemoveAt(0);
            c.Execute();
        }
    }
}

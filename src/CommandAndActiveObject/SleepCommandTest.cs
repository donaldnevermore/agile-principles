using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgilePrinciples.CommandAndActiveObject;

[TestClass]
public class SleepCommandTest {
    private class WakeUpCommand : Command {
        public bool Executed { get; set; } = false;

        public void Execute() {
            Executed = true;
        }
    }

    [TestMethod]
    public void TestSleep() {
        var wakeUp = new WakeUpCommand();
        var e = new ActiveObjectEngine();
        var c = new SleepCommand(1000, e, wakeUp);
        e.AddCommand(c);
        var start = DateTime.Now;
        e.Run();
        var stop = DateTime.Now;
        var sleepTime = (stop - start).TotalMilliseconds;
        Assert.IsTrue(sleepTime >= 1000, $"SleepTime {sleepTime} expected > 1000.");
        Assert.IsTrue(sleepTime <= 1100, $"SleepTime {sleepTime} expected < 1100.");
        Assert.IsTrue(wakeUp.Executed, "Command executed.");
    }
}

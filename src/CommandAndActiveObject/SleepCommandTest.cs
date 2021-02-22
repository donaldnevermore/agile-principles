using System;
using NUnit.Framework;

namespace AgileSoftwareDevelopment.CommandAndActiveObject {
    [TestFixture]
    public class SleepCommandTest {
        private class WakeUpCommand : Command {
            public bool Executed { get; set; } = false;

            public void Execute() {
                Executed = true;
            }
        }

        [Test]
        public void TestSleep() {
            var wakeUp = new WakeUpCommand();
            var e = new ActiveObjectEngine();
            var c = new SleepCommand(1000, e, wakeUp);
            e.AddCommand(c);
            var start = DateTime.Now;
            e.Run();
            var stop = DateTime.Now;
            var sleepTime = (stop - start).TotalMilliseconds;
            Assert.IsTrue(sleepTime >= 1000, $"SleepTime {sleepTime} expected > 1000");
            Assert.IsTrue(sleepTime <= 1100, $"SleepTime {sleepTime} expected < 1100");
            Assert.IsTrue(wakeUp.Executed, "Command executed");
        }
    }
}

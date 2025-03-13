using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileSoftwareDevelopment.Observer;

[TestClass]
public class ObserverTest {
    private MockTimeSource source;
    private MockTimeSink sink;

    [TestInitialize]
    public void SetUp() {
        source = new MockTimeSource();
        sink = new MockTimeSink(source);
        source.RegisterObserver(sink);
    }

    [TestMethod]
    public void TestTimeChange() {
        source.SetTime(3, 4, 5);
        AssertSinkEquals(sink, 3, 4, 5);

        source.SetTime(7, 8, 9);
        AssertSinkEquals(sink, 7, 8, 9);
    }

    [TestMethod]
    public void TestMultipleSinks() {
        var sink2 = new MockTimeSink(source);
        source.RegisterObserver(sink2);

        source.SetTime(12, 13, 14);
        AssertSinkEquals(sink, 12, 13, 14);
        AssertSinkEquals(sink2, 12, 13, 14);
    }

    private static void AssertSinkEquals(MockTimeSink sink, int hours, int mins, int secs) {
        Assert.AreEqual(hours, sink.Hours);
        Assert.AreEqual(mins, sink.Minutes);
        Assert.AreEqual(secs, sink.Seconds);
    }
}

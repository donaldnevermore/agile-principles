using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgilePrinciples.Visitor;

[TestClass]
public class ModemVisitorTest {
    private UnixModemConfigurator v;
    private HayesModem h;
    private ZoomModem z;
    private ErnieModem e;

    [TestInitialize]
    public void SetUp() {
        v = new UnixModemConfigurator();
        h = new HayesModem();
        z = new ZoomModem();
        e = new ErnieModem();
    }

    [TestMethod]
    public void HayesForUnix() {
        h.Accept(v);
        Assert.AreEqual("&s1=4&D=3", h.ConfigurationString);
    }

    [TestMethod]
    public void ZoomForUnix() {
        z.Accept(v);
        Assert.AreEqual(42, z.ConfigurationValue);
    }

    [TestMethod]
    public void ErnieForUnix() {
        e.Accept(v);
        Assert.AreEqual("C is too slow", e.InternalPattern);
    }
}

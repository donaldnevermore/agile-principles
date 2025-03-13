using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileSoftwareDevelopment.SingletonAndMonostate;

[TestClass]
public class TurnstileTest {
    [TestInitialize]
    public void SetUp() {
        var t = new Turnstile();
        t.Reset();
    }

    [TestMethod]
    public void TestInit() {
        var t = new Turnstile();
        Assert.IsTrue(t.IsLocked);
        Assert.IsFalse(t.IsAlarming);
    }

    [TestMethod]
    public void TestCoin() {
        var t = new Turnstile();
        t.Coin();
        var t1 = new Turnstile();
        Assert.IsFalse(t1.IsLocked);
        Assert.IsFalse(t1.IsAlarming);
        Assert.AreEqual(1, t1.Coins);
    }

    [TestMethod]
    public void TestCoinAndPass() {
        var t = new Turnstile();
        t.Coin();
        t.Pass();

        var t1 = new Turnstile();
        Assert.IsTrue(t1.IsLocked);
        Assert.IsFalse(t1.IsAlarming);
        Assert.AreEqual(1, t1.Coins, "coins");
    }

    [TestMethod]
    public void TestTwoCoins() {
        var t = new Turnstile();
        t.Coin();
        t.Coin();

        var t1 = new Turnstile();
        Assert.IsFalse(t1.IsLocked, "unlocked");
        Assert.AreEqual(1, t1.Coins, "coins");
        Assert.AreEqual(1, t1.Refunds, "refunds");
        Assert.IsFalse(t1.IsAlarming);
    }

    [TestMethod]
    public void TestPass() {
        var t = new Turnstile();
        t.Pass();

        var t1 = new Turnstile();
        Assert.IsTrue(t1.IsAlarming, "alarm");
        Assert.IsTrue(t1.IsLocked, "locked");
    }

    [TestMethod]
    public void TestCancelAlarm() {
        var t = new Turnstile();
        t.Pass();
        t.Coin();

        var t1 = new Turnstile();
        Assert.IsFalse(t1.IsAlarming, "alarm");
        Assert.IsFalse(t1.IsLocked, "locked");
        Assert.AreEqual(1, t1.Coins, "coins");
        Assert.AreEqual(0, t1.Refunds, "refunds");
    }

    [TestMethod]
    public void TestTwoOperations() {
        var t = new Turnstile();
        t.Coin();
        t.Pass();
        t.Coin();
        Assert.IsFalse(t.IsLocked, "unlocked");
        Assert.AreEqual(2, t.Coins, "coins");
        t.Pass();
        Assert.IsTrue(t.IsLocked, "locked");
    }
}

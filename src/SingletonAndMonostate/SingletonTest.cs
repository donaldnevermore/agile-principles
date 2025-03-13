using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgilePrinciples.SingletonAndMonostate;

[TestClass]
public class SingletonTest {
    [TestMethod]
    public void TestCreateSingleton() {
        var s = Singleton.Instance;
        var s2 = Singleton.Instance;
        Assert.AreSame(s, s2);
    }

    [TestMethod]
    public void TestNoPublicConstructors() {
        var singleton = typeof(Singleton);
        var ctors = singleton.GetConstructors();
        var hasPublicConstructor = false;
        foreach (var c in ctors) {
            if (c.IsPublic) {
                hasPublicConstructor = true;
                break;
            }
        }

        Assert.IsFalse(hasPublicConstructor);
    }
}

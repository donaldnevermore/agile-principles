using NUnit.Framework;

namespace AgileSoftwareDevelopment.SingletonAndMonostate;

[TestFixture]
public class SingletonTest {
    [Test]
    public void TestCreateSingleton() {
        var s = Singleton.Instance;
        var s2 = Singleton.Instance;
        Assert.AreSame(s, s2);
    }

    [Test]
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

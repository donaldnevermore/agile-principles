using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgilePrinciples.ProxyAndGateway;

[TestClass]
public class ProxyTest {
    [TestInitialize]
    public void SetUp() {
        DB.Init();
        ProductData pd = new ProductData();
        pd.Sku = "ProxyTest1";
        pd.Name = "ProxyTestName1";
        pd.Price = 456;
        DB.Store(pd);
    }

    [TestCleanup]
    public void TearDown() {
        DB.DeleteProductData("ProxyTest1");
        DB.Close();
    }

    [TestMethod]
    public void ProductProxy() {
        Product p = new ProductProxy("ProxyTest1");
        Assert.AreEqual(456, p.Price);
        Assert.AreEqual("ProxyTestName1", p.Name);
        Assert.AreEqual("ProxyTest1", p.Sku);
    }
}

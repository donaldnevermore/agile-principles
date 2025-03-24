using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgilePrinciples.ProxyAndGateway;

[TestClass]
public class OrderTests {
    [TestMethod]
    public void TestOrderPrice() {
        // Order o = new Order("Bob");
        // Product toothpaste = new Product("Toothpaste", 129);
        // o.AddItem(toothpaste, 1);
        // Assert.AreEqual(129, o.Total);
        // Product mouthwash = new Product("Mouthwash", 342);
        // o.AddItem(mouthwash, 2);
        // Assert.AreEqual(813, o.Total);
    }

    [TestMethod]
    public void OrderProxyTotal() {
        DB.Store(new ProductData("Wheaties", 349, "wheaties"));
        DB.Store(new ProductData("Crest", 258, "crest"));
        ProductProxy wheaties = new ProductProxy("wheaties");
        ProductProxy crest = new ProductProxy("crest");
        OrderData od = DB.NewOrder("testOrderProxy");
        OrderProxy order = new OrderProxy(od.OrderId);
        order.AddItem(crest, 1);
        order.AddItem(wheaties, 2);
        Assert.AreEqual(956, order.Total);
    }
}

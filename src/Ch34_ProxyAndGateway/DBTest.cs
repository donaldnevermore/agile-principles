using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgilePrinciples.ProxyAndGateway;

[TestClass]
public class DBTest {
    [TestInitialize]
    public void SetUp() {
        DB.Init();
    }

    [TestCleanup]
    public void TearDown() {
        DB.Close();
    }

    [TestMethod]
    public void StoreProduct() {
        ProductData storedProduct = new ProductData("MyProduct", 1234, "999");
        DB.Store(storedProduct);

        ProductData retrievedProduct = DB.GetProductData("999");
        DB.DeleteProductData("999");
        Assert.AreEqual(storedProduct, retrievedProduct);
    }

    [TestMethod]
    public void OrderKeyGenerate() {
        OrderData o1 = DB.NewOrder("Bob");
        OrderData o2 = DB.NewOrder("Bill");
        int firstOrderId = o1.OrderId;
        int secondOrderId = o2.OrderId;
        Assert.AreEqual(firstOrderId + 1, secondOrderId);
    }

    [TestMethod]
    public void StoreItem() {
        ItemData storeItem = new ItemData(1, 3, "sku");
        DB.Store(storeItem);
        ItemData[] retrievedItems = DB.GetItemsForOrders(1);
        Assert.AreEqual(1, retrievedItems.Length);
        Assert.AreEqual(storeItem, retrievedItems[0]);
    }

    [TestMethod]
    public void NoItems() {
        ItemData[] id = DB.GetItemsForOrders(42);
        Assert.AreEqual(0, id.Length);
    }
}

namespace AgilePrinciples.ProxyAndGateway;

public class OrderData {
    public string CustomerId { get; set; }

    public int OrderId { get; set; }

    public OrderData(int orderId, string customerId) {
        this.CustomerId = customerId;
        this.OrderId = orderId;
    }
}

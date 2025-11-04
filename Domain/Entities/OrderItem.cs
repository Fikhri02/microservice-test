// Domain/Entities/OrderItem.cs
public class OrderItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Money Price { get; private set; }
    public Money Total => new(Price.Amount * Quantity);

    public OrderItem(Guid productId, int quantity, Money price)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
}

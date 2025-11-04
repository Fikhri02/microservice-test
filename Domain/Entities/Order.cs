// Domain/Entities/Order.cs
public class Order
{
    private readonly List<OrderItem> _items = new();
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public Money Total => new(_items.Sum(i => i.Total.Amount));

    public void AddItem(Guid productId, int quantity, Money price)
    {
        var item = new OrderItem(productId, quantity, price);
        _items.Add(item);
    }
}

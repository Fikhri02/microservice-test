// Application/Handlers/CreateOrderHandler.cs
using MediatR;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _repo;

    public CreateOrderHandler(IOrderRepository repo) => _repo = repo;

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken ct)
    {
        var order = new Order();
        foreach (var item in request.Items)
            order.AddItem(item.ProductId, item.Quantity, new Money(item.Price));

        await _repo.AddAsync(order);
        await _repo.SaveChangesAsync();

        return order.Id;
    }
}

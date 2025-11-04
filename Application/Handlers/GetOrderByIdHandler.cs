// Application/Handlers/GetOrderByIdHandler.cs
using MediatR;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly IOrderRepository _repo;
    public GetOrderByIdHandler(IOrderRepository repo) => _repo = repo;

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken ct)
    {
        var order = await _repo.GetByIdAsync(request.Id);
        if (order == null) return null;

        return new OrderDto(order.Id, order.CreatedAt, order.Total.Amount);
    }
}

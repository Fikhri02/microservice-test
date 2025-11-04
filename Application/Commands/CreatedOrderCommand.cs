using MediatR;

// Application/Commands/CreateOrderCommand.cs
public record CreateOrderCommand(List<OrderItemDto> Items) : IRequest<Guid>;

public record OrderItemDto(Guid ProductId, int Quantity, decimal Price);

// Application/Queries/GetOrderByIdQuery.cs
using MediatR;

public record GetOrderByIdQuery(Guid Id) : IRequest<OrderDto>;

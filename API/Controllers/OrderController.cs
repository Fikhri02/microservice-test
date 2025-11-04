// API/Controllers/OrdersController.cs
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand cmd)
    {
        var id = await _mediator.Send(cmd);
        return Ok(new { OrderId = id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        return order == null ? NotFound() : Ok(order);
    }
}

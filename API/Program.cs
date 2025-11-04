using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Register Layers
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("OrdersDb"));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
// builder.Services.AddMediatR(typeof(CreateOrderHandler).Assembly);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateOrderHandler>());

var app = builder.Build();

app.MapControllers();
app.Run();

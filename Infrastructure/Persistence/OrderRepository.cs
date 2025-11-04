// Infrastructure/Persistence/OrderRepository.cs
using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context) => _context = context;

    public async Task<Order?> GetByIdAsync(Guid id) =>
        await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);

    public async Task AddAsync(Order order) => await _context.Orders.AddAsync(order);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}

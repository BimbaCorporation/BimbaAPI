using Domain.OrderHistory;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class OrderHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task AddOrderHistoryAsync(OrderHistory orderHistory)
        {
            await _context.OrderHistoryes.AddAsync(orderHistory);
            await _context.SaveChangesAsync();
        }

        // Read
        public async Task<OrderHistory?> GetOrderHistoryByIdAsync(OrderHistoryId id)
        {
            return await _context.OrderHistoryes
                .Include(oh => oh.Orders) // Якщо Orders є навігаційною властивістю
                .FirstOrDefaultAsync(oh => oh.Id == id);
        }

        public async Task<IEnumerable<OrderHistory>> GetAllOrderHistoriesAsync()
        {
            return await _context.OrderHistoryes
                .Include(oh => oh.Orders) // Якщо Orders є навігаційною властивістю
                .ToListAsync();
        }

        // Update
        public async Task UpdateOrderHistoryAsync(OrderHistory orderHistory)
        {
            _context.OrderHistoryes.Update(orderHistory);
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteOrderHistoryAsync(OrderHistoryId id)
        {
            var orderHistory = await _context.OrderHistoryes.FindAsync(id);
            if (orderHistory != null)
            {
                _context.OrderHistoryes.Remove(orderHistory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
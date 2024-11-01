using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Domain.OrderHistory;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class OrderHistoryRepository(ApplicationDbContext context) : IOrderHistoryRepository, IOrderHistoryQueries
    {
        // Create
        public async Task AddOrderHistoryAsync(OrderHistory orderHistory)
        {
            await context.OrderHistoryes.AddAsync(orderHistory);
            await context.SaveChangesAsync();
        }

        // Read
        public async Task<OrderHistory?> GetOrderHistoryByIdAsync(OrderHistoryId id)
        {
            return await context.OrderHistoryes
                .Include(oh => oh.Orders) // Якщо Orders є навігаційною властивістю
                .FirstOrDefaultAsync(oh => oh.Id == id);
        }

        public async Task<IEnumerable<OrderHistory>> GetAllOrderHistoriesAsync()
        {
            return await context.OrderHistoryes
                .Include(oh => oh.Orders) // Якщо Orders є навігаційною властивістю
                .ToListAsync();
        }

        // Update
        public async Task UpdateOrderHistoryAsync(OrderHistory orderHistory)
        {
            context.OrderHistoryes.Update(orderHistory);
            await context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteOrderHistoryAsync(OrderHistoryId id)
        {
            var orderHistory = await context.OrderHistoryes.FindAsync(id);
            if (orderHistory != null)
            {
                context.OrderHistoryes.Remove(orderHistory);
                await context.SaveChangesAsync();
            }
        }
    }
}
using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Domain.Order;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class OrderRepository (ApplicationDbContext context) : IOrderRepository, IOrderQueries
    {
        // CREATE: Додає нове замовлення до бази даних
        public async Task AddAsync(Orders orders)
        {
            await context.Orders.AddAsync(orders);
            await context.SaveChangesAsync();
        }

        // READ: Отримує замовлення за його ідентифікатором
        public async Task<Orders?> GetByIdAsync(OrderId orderId)
        {
            return await context.Orders
                .Include(o => o.Items) // Завантажує також елементи замовлення
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        // UPDATE: Оновлює існуюче замовлення
        public async Task UpdateAsync(Orders orders)
        {
            context.Orders.Update(orders);
            await context.SaveChangesAsync();
        }

        // DELETE: Видаляє замовлення за його ідентифікатором
        public async Task DeleteAsync(OrderId orderId)
        {
            var order = await GetByIdAsync(orderId);
            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
        }

        // Отримання всіх замовлень
        public async Task<List<Orders>> GetAllAsync()
        {
            return await context.Orders
                .Include(o => o.Items) // Завантажує елементи замовлення
                .ToListAsync();
        }

        // Отримує всі замовлення певного користувача за його ID
        public async Task<List<Orders>> GetByUserIdAsync(UserId userId)
        {
            return await context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                .ToListAsync();
        }
    }
}

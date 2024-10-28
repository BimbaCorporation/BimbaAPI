using Domain.Order;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE: Додає нове замовлення до бази даних
        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        // READ: Отримує замовлення за його ідентифікатором
        public async Task<Order?> GetByIdAsync(OrderId orderId)
        {
            return await _context.Orders
                .Include(o => o.Items) // Завантажує також елементи замовлення
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        // UPDATE: Оновлює існуюче замовлення
        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        // DELETE: Видаляє замовлення за його ідентифікатором
        public async Task DeleteAsync(OrderId orderId)
        {
            var order = await GetByIdAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        // Отримання всіх замовлень
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Items) // Завантажує елементи замовлення
                .ToListAsync();
        }

        // Отримує всі замовлення певного користувача за його ID
        public async Task<List<Order>> GetByUserIdAsync(UserId userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                .ToListAsync();
        }
    }
}

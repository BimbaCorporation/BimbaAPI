using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Domain.OrderItem;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class OrderItemRepository(ApplicationDbContext context) : IOrderItemRepository, IOrderItemQueries
{
    // Create
    public async Task AddAsync(OrderItem orderItem)
    {
        await context.OrderItems.AddAsync(orderItem);
        await context.SaveChangesAsync();
    }

    // Read
    public async Task<OrderItem?> GetByIdAsync(OrderItemId id)
    {
        return await context.OrderItems.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
    {
        return await context.OrderItems.ToListAsync();
    }

    // Update
    public async Task UpdateAsync(OrderItem orderItem)
    {
        context.OrderItems.Update(orderItem);
        await context.SaveChangesAsync();
    }

    // Delete
    public async Task DeleteAsync(OrderItemId id)
    {
        var orderItem = await GetByIdAsync(id);
        if (orderItem != null)
        {
            context.OrderItems.Remove(orderItem);
            await context.SaveChangesAsync();
        }
    }
}
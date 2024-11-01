using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Domain.CartItem;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CartItemRepository (ApplicationDbContext context) : ICartItemRepository, ICartItemQueries
{
    // Створення нового CartItem
    public async Task<CartItems> CreateAsync(CartItems cartItems)
    {
        await context.CartItems.AddAsync(cartItems);
        await context.SaveChangesAsync();
        return cartItems;
    }

    // Отримання CartItem за ідентифікатором
    public async Task<CartItems?> GetByIdAsync(Guid id)
    {
        return await context.CartItems.FindAsync(id);
    }

    // Отримання всіх CartItem
    public async Task<List<CartItems>> GetAllAsync()
    {
        return await context.CartItems.ToListAsync();
    }

    // Оновлення CartItem
    public async Task UpdateAsync(CartItems cartItems)
    {
        context.CartItems.Update(cartItems);
        await context.SaveChangesAsync();
    }

    // Видалення CartItem за ідентифікатором
    public async Task DeleteAsync(Guid id)
    {
        var cartItem = await GetByIdAsync(id);
        if (cartItem != null)
        {
            context.CartItems.Remove(cartItem);
            await context.SaveChangesAsync();
        }
    }
}
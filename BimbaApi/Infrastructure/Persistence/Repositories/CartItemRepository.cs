using Domain.CartItem;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CartItemRepository
{
    private readonly ApplicationDbContext _context;

    public CartItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Створення нового CartItem
    public async Task<CartItem> CreateAsync(CartItem cartItem)
    {
        await _context.CartItems.AddAsync(cartItem);
        await _context.SaveChangesAsync();
        return cartItem;
    }

    // Отримання CartItem за ідентифікатором
    public async Task<CartItem?> GetByIdAsync(Guid id)
    {
        return await _context.CartItems.FindAsync(id);
    }

    // Отримання всіх CartItem
    public async Task<List<CartItem>> GetAllAsync()
    {
        return await _context.CartItems.ToListAsync();
    }

    // Оновлення CartItem
    public async Task UpdateAsync(CartItem cartItem)
    {
        _context.CartItems.Update(cartItem);
        await _context.SaveChangesAsync();
    }

    // Видалення CartItem за ідентифікатором
    public async Task DeleteAsync(Guid id)
    {
        var cartItem = await GetByIdAsync(id);
        if (cartItem != null)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}
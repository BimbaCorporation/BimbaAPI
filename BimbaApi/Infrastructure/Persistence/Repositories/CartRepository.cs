using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Cart;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create: Додати новий Cart
        public async Task<Cart> CreateAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        // Read: Отримати Cart за UserId
        public async Task<Cart> GetByUserIdAsync(UserId userId)
        {
            return await _context.Carts
                .Include(c => c.Items) // Якщо потрібно включити Items
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        // Update: Оновити існуючий Cart
        public async Task<Cart> UpdateAsync(Cart cart)
        {
            var existingCart = await _context.Carts.FindAsync(cart.UserId);
            if (existingCart == null)
            {
                throw new Exception("Cart not found");
            }

            existingCart.Items = cart.Items; // Оновлюємо Items
            await _context.SaveChangesAsync();
            return existingCart;
        }

        // Delete: Видалити Cart за UserId
        public async Task DeleteAsync(UserId userId)
        {
            var cart = await _context.Carts.FindAsync(userId);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
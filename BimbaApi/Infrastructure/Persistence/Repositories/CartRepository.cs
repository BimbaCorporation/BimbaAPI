using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Domain.Cart;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories 
{
    public class CartRepository (ApplicationDbContext context) : ICartRepository, ICartQueries
    {
        // Create: Додати новий Cart
        public async Task<Cart> CreateAsync(Cart cart)
        {
            await context.Carts.AddAsync(cart);
            await context.SaveChangesAsync();
            return cart;
        }

        // Read: Отримати Cart за UserId
      

        // Update: Оновити існуючий Cart
        public async Task<Cart> UpdateAsync(Cart cart)
        {
            var existingCart = await context.Carts.FindAsync(cart.CartId);
            if (existingCart == null)
            {
                throw new Exception("Cart not found");
            }

            existingCart.Items = cart.Items; // Оновлюємо Items
            await context.SaveChangesAsync();
            return existingCart;
        }

        // Delete: Видалити Cart за UserId
        public async Task DeleteAsync(UserId userId)
        {
            var cart = await context.Carts.FindAsync(userId);
            if (cart != null)
            {
                context.Carts.Remove(cart);
                await context.SaveChangesAsync();
            }
        }
    }
}
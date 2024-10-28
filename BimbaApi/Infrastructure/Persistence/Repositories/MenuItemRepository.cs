using Domain.MenuItem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class MenuItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create - Додавання нового MenuItem
        public async Task AddAsync(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        // Read - Отримання MenuItem за ідентифікатором
        public async Task<MenuItem?> GetByIdAsync(MenuItemId id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        // Read - Отримання всіх MenuItem
        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        // Update - Оновлення існуючого MenuItem
        public async Task UpdateAsync(MenuItem menuItem)
        {
            var existingItem = await _context.MenuItems.FindAsync(menuItem.Id);
            if (existingItem != null)
            {
                existingItem = menuItem; // Update the properties of existing item as needed
                _context.MenuItems.Update(existingItem);
                await _context.SaveChangesAsync();
            }
        }

        // Delete - Видалення MenuItem за ідентифікатором
        public async Task DeleteAsync(MenuItemId id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
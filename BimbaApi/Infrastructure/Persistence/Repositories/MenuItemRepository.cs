using Domain.MenuItem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class MenuItemRepository(ApplicationDbContext context) : IMenuItemRepository, IMenuItemQueries
    {

        // Create - Додавання нового MenuItem
        public async Task AddAsync(MenuItems menuItems)
        {
            await context.MenuItems.AddAsync(menuItems);
            await context.SaveChangesAsync();
        }

        // Read - Отримання MenuItem за ідентифікатором
        public async Task<MenuItems?> GetByIdAsync(MenuItemId id)
        {
            return await context.MenuItems.FindAsync(id);
        }

        // Read - Отримання всіх MenuItem
        public async Task<List<MenuItems>> GetAllAsync()
        {
            return await context.MenuItems.ToListAsync();
        }

        // Update - Оновлення існуючого MenuItem
        public async Task UpdateAsync(MenuItems menuItems)
        {
            var existingItem = await context.MenuItems.FindAsync(menuItems.Id);
            if (existingItem != null)
            {
                existingItem = menuItems; // Update the properties of existing item as needed
                context.MenuItems.Update(existingItem);
                await context.SaveChangesAsync();
            }
        }

        // Delete - Видалення MenuItem за ідентифікатором
        public async Task DeleteAsync(MenuItemId id)
        {
            var menuItem = await context.MenuItems.FindAsync(id);
            if (menuItem != null)
            {
                context.MenuItems.Remove(menuItem);
                await context.SaveChangesAsync();
            }
        }
    }
}
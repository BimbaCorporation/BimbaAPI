using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository, IUserQueries
{
    // CREATE
    public async Task AddUserAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    // READ
    public async Task<User?> GetUserByIdAsync(UserId id)
    {
        return await context.Users
            .Include(u => u.UsersInfo)
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await context.Users
            .Include(u => u.UsersInfo)
            .Include(u => u.Orders)
            .ToListAsync();
    }

    // UPDATE
    public async Task UpdateUserAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteUserAsync(UserId id)
    {
        var user = await GetUserByIdAsync(id);
        if (user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
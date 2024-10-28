using Domain.UserInfo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserInfoRepository
{
    private readonly ApplicationDbContext _context;

    public UserInfoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task<UserInfo> CreateAsync(UserInfo userInfo)
    {
        await _context.UserInfos.AddAsync(userInfo);
        await _context.SaveChangesAsync();
        return userInfo;
    }

    // Read
    public async Task<UserInfo?> GetByIdAsync(UserInfoId id)
    {
        return await _context.UserInfos
            .Include(u => u.Address) // Підключаємо Address, якщо він може бути null, краще використати ThenInclude
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<UserInfo>> GetAllAsync()
    {
        return await _context.UserInfos
            .Include(u => u.Address)
            .ToListAsync();
    }

    // Update
    public async Task<bool> UpdateAsync(UserInfo userInfo)
    {
        var existingUserInfo = await _context.UserInfos.FindAsync(userInfo.Id);
        if (existingUserInfo == null)
            return false;

        existingUserInfo.UpdateContactInfo(userInfo.Email, userInfo.PhoneNumber, userInfo.Address);
        _context.UserInfos.Update(existingUserInfo);
        await _context.SaveChangesAsync();
        return true;
    }

    // Delete
    public async Task<bool> DeleteAsync(UserInfoId id)
    {
        var userInfo = await _context.UserInfos.FindAsync(id);
        if (userInfo == null)
            return false;

        _context.UserInfos.Remove(userInfo);
        await _context.SaveChangesAsync();
        return true;
    }
}
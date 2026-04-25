using AuthService.Application.Services;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using AuthService.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Repositories;

public class AdminRepository(ApplicationDbContext context) : IAdminRepository
{
    public async Task<Admin?> GetByIdAsync(string id)
    {
        var admin = await context.Admins
        .FirstOrDefaultAsync(a => a.Id == id);
        return admin;
    }

    public async Task<Admin> CreateAsync(Admin admin)
    {
        context.Admins.Add(admin);
        await context.SaveChangesAsync();
        return await GetByIdAsync(admin.Id);
    }


    public async Task<Admin?> GetByEmailAsync(string email)
    {
        var admin = await context.Admins
        .FirstOrDefaultAsync(a => EF.Functions.Like(a.Email, email));
        return admin;
    }

    public async Task<IEnumerable<Admin>> GetAllAsync()
    {
        var admins = await context.Admins
        .ToListAsync();
        return admins;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await context.Admins
        .AnyAsync(a => EF.Functions.Like(a.Email, email));
    }

    public async Task<Admin> UpdateAsync(Admin admin)
    {
        await context.SaveChangesAsync();
        return await GetByIdAsync(admin.Id);
    }

    public async Task<bool> UpdateStatusAsync(string id, string status)
    {
        var existingAdmin = await context.Admins.Where(a => a.Id == id).ToListAsync();

        context.Admins.RemoveRange(existingAdmin);

        var updateAdmin = new Admin
        {
            Id = id,
            Name = existingAdmin.FirstOrDefault().Name,
            Email = existingAdmin.FirstOrDefault().Email,
            Password = existingAdmin.FirstOrDefault().Password,
            Status = status,
            CreationDate = existingAdmin.FirstOrDefault().CreationDate
        };
        context.Admins.Add(updateAdmin);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var admin = await GetByIdAsync(id);
        context.Admins.Remove(admin);
        await context.SaveChangesAsync();
        return true;
    }
}
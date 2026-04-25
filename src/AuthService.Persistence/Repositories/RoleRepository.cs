using AuthService.Application.Services;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using AuthService.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Repositories;

public class RoleRepository(ApplicationDbContext context) : IRoleRepository
{
    public async Task<Role>  GetByNameAsync(string name)
    {
        return await context.Roles
        .Include(r => r.UserRoles)
        .FirstOrDefaultAsync(r => EF.Functions.Like(r.Name, name));
    }

    public async Task<int> CountUsersInRoleAsync(string roleName)
    {
        return await context.UserRoles
        .Where(ur => ur.Role.Name == roleName)
        .CountAsync();
    }

    public async Task<IReadOnlyList<User>> GetUsersByRoleAsync(string roleName)
    {
        return await context.UserRoles
        .Where(ur => ur.Role.Name == roleName)
        .Select(ur => ur.User)
        .Include(u => u.UserRoles)
        .Include(u => u.UserAccount)
        .Include(u => u.UserEmail)
        .ToListAsync()
        .ContinueWith(t => (IReadOnlyList<User>)t.Result);
    }

    public async Task<IReadOnlyList<string>> GetUserRoleNameAsync(string userId)
    {
        return await context.UserRoles
        .Where(ur => ur.UserId == userId)
        .Select(ur => ur.Role.Name)
        .ToListAsync()
        .ContinueWith(t => (IReadOnlyList<string>)t.Result);
    }
}

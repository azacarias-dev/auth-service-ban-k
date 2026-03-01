using AuthService.Domain.Entities;
using AuthService.Persistence.Data;
using AuthService.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!await context.Roles.AnyAsync())
        {
            var adminRole = new Role
            {
                Id = UuidGenerator.GenerateRoleId(),
                Name = "Admin",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var userRole = new Role
            {
                Id = UuidGenerator.GenerateRoleId(),
                Name = "User",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await context.Roles.AddRangeAsync(adminRole, userRole);
            await context.SaveChangesAsync();
        }

        var adminEmail = "ADMIN01@GMAIL.COM";

        var existingAdmin = await context.Users
            .FirstOrDefaultAsync(u => u.Email == adminEmail);

        if (existingAdmin != null)
            return;

        var adminUser = new User
        {
            Id = UuidGenerator.GenerateUserId(),
            Name = "ADMIN01",
            Email = adminEmail,
            Password = "ADMIN01",

            Phone = "00000000",
            Dpi = "0000000000001",
            Address = "SYSTEM ADDRESS",
            JobName = "SYSTEM ADMIN",
            MonthlyIncome = 0,
            Birthdate = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        await context.Users.AddAsync(adminUser);
        await context.SaveChangesAsync();

        var adminRoleDb = await context.Roles
            .FirstOrDefaultAsync(r => r.Name == "Admin");

        if (adminRoleDb != null)
        {
            var userRole = new UserRole
            {
                Id = UuidGenerator.GenerateShortUUID(),
                UserId = adminUser.Id,
                RoleId = adminRoleDb.Id,
                AssignedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await context.UserRoles.AddAsync(userRole);
        }

        var userEmail = new UserEmail
        {
            Id = UuidGenerator.GenerateShortUUID(),
            UserId = adminUser.Id,
            EmailVerified = true,
            EmailVerificationToken = null,
            EmailVerificationTokenExpiry = null
        };

        await context.UserEmails.AddAsync(userEmail);

        var passwordReset = new UserPasswordReset
        {
            Id = UuidGenerator.GenerateShortUUID(),
            UserId = adminUser.Id,
            PasswordResetToken = null,
            PasswordResetTokenExpiry = null
        };

        await context.UserPasswordResets.AddAsync(passwordReset);

        await context.SaveChangesAsync();
    }
}
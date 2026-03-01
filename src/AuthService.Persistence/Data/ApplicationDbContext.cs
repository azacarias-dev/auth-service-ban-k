using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets (Tablas)
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserEmail> UserEmails { get; set; }
    public DbSet<UserPasswordReset> UserPasswordResets { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Admin> Admins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // USER
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.Dpi).IsUnique();

            entity.HasMany(e => e.UserRoles)
                  .WithOne(ur => ur.User)
                  .HasForeignKey(ur => ur.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.UserAccount)
                  .WithOne(ua => ua.User)
                  .HasForeignKey<UserAccount>(ua => ua.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.UserEmail)
                  .WithOne(ue => ue.User)
                  .HasForeignKey<UserEmail>(ue => ue.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.UserPasswordReset)
                  .WithOne(upr => upr.User)
                  .HasForeignKey<UserPasswordReset>(upr => upr.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });


        // ROLE
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Name).IsUnique();

            entity.HasMany(e => e.UserRoles)
                  .WithOne(ur => ur.Role)
                  .HasForeignKey(ur => ur.RoleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // USER ROLE (Tabla Intermedia)
        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => new { e.UserId, e.RoleId })
                  .IsUnique();
        });


        // USER ACCOUNT
        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.DocumentoIdentidad).IsUnique();
            entity.HasIndex(e => e.NumeroCuenta).IsUnique();
            entity.HasIndex(e => e.Correo).IsUnique();
        });

        // ADMIN
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Email).IsUnique();
        });


        // Convertir CamelCase a snake_case
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName))
                entity.SetTableName(ToSnakeCase(tableName));

            foreach (var property in entity.GetProperties())
            {
                var columnName = property.GetColumnName();
                if (!string.IsNullOrEmpty(columnName))
                    property.SetColumnName(ToSnakeCase(columnName));
            }
        }
    }

    // Método para convertir a snake_case
    private static string ToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return string.Concat(
            input.Select((x, i) =>
                i > 0 && char.IsUpper(x)
                    ? "_" + x.ToString().ToLower()
                    : x.ToString().ToLower())
        );
    }
}
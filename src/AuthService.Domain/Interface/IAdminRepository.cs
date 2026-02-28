using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces;

public interface IUserRepository
{
    // Métodos de creación
    Task<User> CreateAsync(User user);

    // Métodos de consulta
    Task<User?> GetByIdAsync(string id);

    Task<User?> GetByEmailAsync(string email);

    Task<IEnumerable<User>> GetAllAsync();

    // Validaciones
    Task<bool> ExistsByEmailAsync(string email);

    // Métodos de actualización
    Task<User> UpdateAsync(User user);

    Task<bool> UpdateStatusAsync(string id, string status);

    // Método de eliminación
    Task<bool> DeleteAsync(string id);
}
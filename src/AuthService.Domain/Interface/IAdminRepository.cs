using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces;

public interface IAdminRepository
{
    // Métodos de creación
    Task<Admin> CreateAsync(Admin admin);

    // Métodos de consulta
    Task<Admin?> GetByIdAsync(string id);

    Task<Admin?> GetByEmailAsync(string email);

    Task<IEnumerable<Admin>> GetAllAsync();

    // Validaciones
    Task<bool> ExistsByEmailAsync(string email);

    // Métodos de actualización
    Task<Admin> UpdateAsync(Admin admin);

    Task<bool> UpdateStatusAsync(string id, string status);

    // Método de eliminación
    Task<bool> DeleteAsync(string id);
}
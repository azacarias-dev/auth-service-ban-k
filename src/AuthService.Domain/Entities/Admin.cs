using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities;

public class Admin
{
    [Key]
    [MaxLength(16)]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nombre es requerido.")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Correo es requerido.")]
    [EmailAddress(ErrorMessage = "Formato de correo invalido.")]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password es requerido.")]
    [MinLength(8, ErrorMessage = "Password debe tener al menos 8 caracteres.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Status es requerido.")]
    [MaxLength(20)]
    public string Status { get; set; } = string.Empty;

    [Required(ErrorMessage = "Creation date es requerido.")]
    public DateTime CreationDate { get; set; }
}
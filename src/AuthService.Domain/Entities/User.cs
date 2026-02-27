using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities;

public class User
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

    [Required(ErrorMessage = "Phone es requerido.")]
    [Phone(ErrorMessage = "Formato de numero de telefono invalido.")]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "DPI es requerido.")]
    [MaxLength(20)]
    public string Dpi { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address es requerido.")]
    [MaxLength(150)]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Job name es requerido.")]
    [MaxLength(100)]
    public string JobName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Monthly income es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "Monthly income debe ser mayor o igual a 0.")]
    public decimal MonthlyIncome { get; set; }

    [Required(ErrorMessage = "Birthdate es requerido.")]
    public DateTime Birthdate { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required(ErrorMessage = "Active status es requerido.")]
    public bool IsActive { get; set; } = true;
}
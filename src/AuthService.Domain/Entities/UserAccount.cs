using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities;

public class UserAccount
{
    [Key]
    [MaxLength(16)]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Full name is required.")]
    [MaxLength(100)]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "Identity document is required.")]
    [MaxLength(25)]
    public string DocumentoIdentidad { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    [MaxLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(100)]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Account type is required.")]
    [MaxLength(50)]
    public string TipoCuenta { get; set; } = string.Empty;

    [Required(ErrorMessage = "Account number is required.")]
    [MaxLength(30)]
    public string NumeroCuenta { get; set; } = string.Empty;

    [Required(ErrorMessage = "Balance is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Balance must be greater than or equal to 0.")]
    public decimal Saldo { get; set; }

    [Required(ErrorMessage = "Active status is required.")]
    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; }
}
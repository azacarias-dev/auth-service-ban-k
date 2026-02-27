using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities;

public class UserAccount
{
    [Key]
    [MaxLength(16)]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nombre completo es requerido.")]
    [MaxLength(100)]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "Documento de identidad es requerido.")]
    [MaxLength(25)]
    public string DocumentoIdentidad { get; set; } = string.Empty;

    [Required(ErrorMessage = "Numero de telefono es requerido.")]
    [Phone(ErrorMessage = "Formato de numero de telefono invalido.")]
    [MaxLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "Correo es requerido.")]
    [EmailAddress(ErrorMessage = "Formato de correo invalido.")]
    [MaxLength(100)]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tipo de cuenta es requerido.")]
    [MaxLength(50)]
    public string TipoCuenta { get; set; } = string.Empty;

    [Required(ErrorMessage = "Numero de cuenta es requerido.")]
    [MaxLength(30)]
    public string NumeroCuenta { get; set; } = string.Empty;

    [Required(ErrorMessage = "Saldo es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "Saldo debe ser mayor o igual a 0.")]
    public decimal Saldo { get; set; }

    [Required(ErrorMessage = "Estado es requerido.")]
    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; }
}
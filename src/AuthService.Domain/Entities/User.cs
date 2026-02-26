using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities;

public class User
{
    [Key]
    [MaxLength(16)]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "DPI is required.")]
    [MaxLength(20)]
    public string Dpi { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address is required.")]
    [MaxLength(150)]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Job name is required.")]
    [MaxLength(100)]
    public string JobName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Monthly income is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Monthly income must be greater than or equal to 0.")]
    public decimal MonthlyIncome { get; set; }

    [Required(ErrorMessage = "Birthdate is required.")]
    public DateTime Birthdate { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required(ErrorMessage = "Active status is required.")]
    public bool IsActive { get; set; } = true;
}
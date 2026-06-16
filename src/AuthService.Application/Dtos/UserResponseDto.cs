namespace AuthService.Application.DTOs;

public class UserResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address {get; set;} = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Dpi { get; set; } = string.Empty;
    public string JobName { get; set; } = string.Empty;
    public decimal MonthlyIncome { get; set; }
    public DateTime Birthdate { get; set; }
    public string Role { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsEmailVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
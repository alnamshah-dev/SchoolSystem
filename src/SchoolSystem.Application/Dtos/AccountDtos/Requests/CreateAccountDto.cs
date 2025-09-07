using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Application.Dtos.AccountDtos.Requests;

public class CreateAccountDto : LoginDto
{
    [Required, Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = default!;
    [Required]
    public string Role { get; set; } = default!;
}
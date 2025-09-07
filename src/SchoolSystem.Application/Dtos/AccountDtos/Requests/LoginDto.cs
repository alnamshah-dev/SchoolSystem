using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolSystem.Application.Dtos.AccountDtos.Requests;

public class LoginDto
{
    [EmailAddress, Required]
    [RegularExpression("[^@ \\t\\r\\n]+@[^@ \\t\\r\\n]+\\.[^@ \\t\\r\\n]+",
       ErrorMessage = "Your Email is not valid, provide valid email as ...@gmail,@hotmail,etc...")]
    [DisplayName("Email Address")]
    public string EmailAddress { get; set; } = default!;

    [Required]
    [RegularExpression("^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$",
        ErrorMessage = "Your Password must be a mix of Alphanumeric and special characters")]
    public string Password { get; set; } = default!;
}

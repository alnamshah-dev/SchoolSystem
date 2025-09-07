namespace SchoolSystem.Domain.Core.Authentication;
public class RefreshToken
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public string Token { get; set; } = default!;
}

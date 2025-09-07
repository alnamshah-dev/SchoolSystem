namespace SchoolSystem.Application.Dtos.AccountDtos.Responses;

public record LoginResponse(bool Flag = false, string Message = null!, string Token = null!, string RefreshToken = null!);

using SchoolSystem.Application.Dtos.AccountDtos.Requests;
using SchoolSystem.Application.Dtos.AccountDtos.Responses;

namespace SchoolSystem.Application.Data.Authentication
{
    public interface IAccount
    {
        Task<Response> CreateAccountAsync(CreateAccountDto model);
        Task<LoginResponse> LoginAccountAsync(LoginDto model);
        Task<Response> CreateRoleAsync(CreateRoleDto model);
        Task<Response> DeleteUserAsync(string email);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenDto model);
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
    }
}

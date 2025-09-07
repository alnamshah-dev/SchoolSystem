using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Data.Authentication;
using SchoolSystem.Application.Dtos.AccountDtos.Requests;
using SchoolSystem.Application.Dtos.AccountDtos.Responses;

namespace SchoolSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccount Account) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<Response>> CreateAccount(CreateAccountDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model can not be empty");
            return Ok(await Account.CreateAccountAsync(model));
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAccount(LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model can not be empty");
            return Ok(await Account.LoginAccountAsync(model));
        }

        [HttpDelete("delete-account/{email}")]
        public async Task<ActionResult<Response>> DeleteAccount(string email)
        {
            if (!ModelState.IsValid)
                return BadRequest("Email can not be empty");
            return Ok(await Account.DeleteUserAsync(email));
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<LoginResponse>> RefreshToken(RefreshTokenDto model)
        {
            if (!ModelState.IsValid) return BadRequest("Model can not be empty");
            return Ok(await Account.RefreshTokenAsync(model));
        }

        [HttpGet("users")]
        [Authorize(Roles = "Admin,Owner")] // role based
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        {
            return Ok(await Account.GetAllUsersAsync());
        }
        [HttpPost("create-role")]
        public async Task<ActionResult<Response>> CreateRole(CreateRoleDto model)
        {
            if (!ModelState.IsValid) return BadRequest("Model can not be empty");
            return Ok(await Account.CreateRoleAsync(model));
        }
    }
}

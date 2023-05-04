using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs;
using ResumeMaker.Models;
using ResumeMaker.Services;

namespace ResumeMaker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> RegisterUser(RegisterUserDto user)
        {
            var response = await _authService.RegisterUser(user);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> LoginUser(UserLoginDto user)
        {
            var response = await _authService.Login(user);
            return Ok(response);
        }
    }
}

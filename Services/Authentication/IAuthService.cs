using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Services.Authentication
{
    public interface IAuthService
    {
        Task<ServiceResponse<GetUserDto>> RegisterUser(RegisterUserDto user);
        Task<ServiceResponse<GetUserDto>> GetUserByToken(string token);
        Task<ServiceResponse<GetUserDto>> Login(UserLoginDto user);
        Task<ServiceResponse<GetUserDto>> CurrentUser(string token);
        string CreateToken(User user);

    }
}

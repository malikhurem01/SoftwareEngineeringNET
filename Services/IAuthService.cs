using ResumeMaker.API.DTOs;
using ResumeMaker.Models;

namespace ResumeMaker.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<GetUserDto>> RegisterUser(RegisterUserDto user);
        Task<ServiceResponse<GetUserDto>> GetUserByToken(string token);
        Task<ServiceResponse<GetUserDto>> Login(UserLoginDto user);
        string CreateToken(User user);

    }
}

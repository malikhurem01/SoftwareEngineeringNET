using ResumeMaker.API.DTOs;
using ResumeMaker.Models;

namespace ResumeMaker.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<User>> RegisterUser();
        Task<ServiceResponse<User>> GetUserByToken(string token);
        Task<ServiceResponse<GetUserDto>> Login(UserLoginDto user);
    }
}

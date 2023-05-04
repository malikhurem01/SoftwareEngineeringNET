using ResumeMaker.Models;

namespace ResumeMaker.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<User>> RegisterUser();
        Task<ServiceResponse<User>> GetUserByToken(string token);
        ServiceResponse<User> Login(User user);
    }
}

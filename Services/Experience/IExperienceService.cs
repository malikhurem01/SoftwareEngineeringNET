using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Services
{
    public interface IExperienceService
    {
        Task<ServiceResponse<GetExperienceDto>> AddUserExperience(string token, AddExperienceDto userInfo);
        Task<ServiceResponse<GetExperienceDto>> ModifyUserExperience(string token, ModifyExperienceDto userInfo);
    }
}

using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Services
{
    public interface IInformationService
    {
        Task<ServiceResponse<GetEducationDto>> AddUserEducation(string token, AddEducationDto userInfo);
        Task<ServiceResponse<GetExperienceDto>> AddUserExperience(string token, AddExperienceDto userInfo);
        Task<ServiceResponse<GetSkillDto>> AddUserSkill(string token, AddSkillDto userInfo);
        Task<ServiceResponse<GetLanguageDto>> AddUserLanguage(string token, AddLanguageDto userInfo);
        Task<ServiceResponse<GetCardDto>> AddUserCard(string token, AddCardDto userInfo);
    }
}

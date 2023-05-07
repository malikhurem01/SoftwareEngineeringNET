using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Services
{
    public interface ILanguageService
    {
        Task<ServiceResponse<GetLanguageDto>> AddUserLanguage(string token, AddLanguageDto userInfo);
        Task<ServiceResponse<GetLanguageDto>> ModifyUserLanguage(string token, ModifyLanguageDto userInfo);
    }
}

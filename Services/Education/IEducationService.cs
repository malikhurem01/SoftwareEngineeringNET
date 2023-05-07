using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Services
{
    public interface IEducationService
    {
        Task<ServiceResponse<GetEducationDto>> AddUserEducation(string token, AddEducationDto userInfo);
        Task<ServiceResponse<GetEducationDto>> ModifyUserEducation(string token, ModifyEducationDto userInfo);
    }
}

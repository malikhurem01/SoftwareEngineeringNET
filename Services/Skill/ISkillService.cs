using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Services
{
    public interface ISkillService
    {
        Task<ServiceResponse<GetSkillDto>> AddUserSkill(string token, AddSkillDto userInfo);
        Task<ServiceResponse<GetSkillDto>> ModifyUserSkill(string token, ModifySkillDto userInfo);
    }
}

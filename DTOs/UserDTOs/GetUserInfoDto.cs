using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.DTOs.UserDTOs
{
    public class GetUserInfoDto
    {
        public List<GetEducationDto> Education { get; set; } = new List<GetEducationDto>();
        public List<GetExperienceDto> Experiences { get; set; } = new List<GetExperienceDto>();
        public List<GetSkillDto> Skills { get; set; } = new List<GetSkillDto>();
        public List<GetLanguageDto> Languages { get; set; } = new List<GetLanguageDto>();
    }
}

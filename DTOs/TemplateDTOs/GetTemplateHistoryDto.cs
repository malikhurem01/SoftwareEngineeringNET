using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.DTOs.TemplateDTOs
{
    public class GetTemplateHistoryDto
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public GetUserDto User { get; set; }
        public List<GetExperienceDto> Experience { get; set; }
        public List<GetEducationDto> Education { get; set; }
        public List<GetSkillDto> Skills { get; set; }
        public List<GetLanguageDto> Languages { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}

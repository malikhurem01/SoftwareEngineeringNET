using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.DTOs.TemplateDTOs
{
    public class AddTemplateHistoryDto
    {
        public int? Id { get; set; }
        public int TemplateId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<AddExperienceDto> Experience { get; set; }
        public List<AddEducationDto> Education { get; set; }
        public List<AddSkillDto> Skills { get; set; }
        public List<AddLanguageDto> Languages { get; set; }
    }
}

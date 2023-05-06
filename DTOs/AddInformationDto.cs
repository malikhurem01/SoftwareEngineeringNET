using ResumeMaker.Models;

namespace ResumeMaker.API.DTOs
{
    public class AddInformationDto
    {
        public List<AddEducationDto> Education { get; set; } = new List<AddEducationDto>();
        public List<AddExperienceDto> Experiences { get; set; } = new List<AddExperienceDto>();
        public List<AddSkillDto> Skills { get; set; } = new List<AddSkillDto>();
        public List<AddCardDto> Cards { get; set; } = new List<AddCardDto>();
        public List<AddLanguageDto> Languages { get; set; } = new List<AddLanguageDto>();
    }
}

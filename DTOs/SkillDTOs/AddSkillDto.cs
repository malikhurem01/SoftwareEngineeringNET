
namespace ResumeMaker.API.DTOs.SkillDTOs
{
    public class AddSkillDto
    {
        public int? Id { get; set; }
        public int? TemplateHistoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
    }
}


namespace ResumeMaker.API.DTOs.SkillDTOs
{
    public class GetSkillDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
    }
}

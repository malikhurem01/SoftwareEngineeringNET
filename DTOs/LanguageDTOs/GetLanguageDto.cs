using ResumeMaker.Models;

namespace ResumeMaker.API.DTOs.LanguageDTOs
{
    public class GetLanguageDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}

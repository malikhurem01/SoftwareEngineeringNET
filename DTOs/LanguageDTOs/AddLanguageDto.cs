namespace ResumeMaker.API.DTOs.LanguageDTOs
{
    public class AddLanguageDto
    {
        public int? Id { get; set; }
        public int? TemplateHistoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}

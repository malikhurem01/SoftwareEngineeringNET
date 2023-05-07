namespace ResumeMaker.API.DTOs.LanguageDTOs
{
    public class ModifyLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}

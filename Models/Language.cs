namespace ResumeMaker.Models
{
    public class Language
    {
        public int Id { get; set; }
        public int? TemplateHistoryId { get; set; }
        public TemplateHistory? TemplateHistory { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}

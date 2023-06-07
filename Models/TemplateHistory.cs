namespace ResumeMaker.Models
{
    public class TemplateHistory
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
        public List<Experience>? Experience { get; set; }
        public List<Education>? Education { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<Language>? Languages { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}

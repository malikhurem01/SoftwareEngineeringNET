namespace ResumeMaker.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public int? TemplateHistoryId { get; set; }
        public TemplateHistory? TemplateHistory { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public bool CurrentlyWorking { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; } = string.Empty;
        public string WorkingHours { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}

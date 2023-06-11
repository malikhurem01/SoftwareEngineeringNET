namespace ResumeMaker.API.DTOs.ExperienceDTOs
{
    public class AddExperienceDto
    {
        public int? Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public int? TemplateHistoryId { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public string WorkingHours { get; set; } = string.Empty;
        public bool CurrentlyWorking { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}

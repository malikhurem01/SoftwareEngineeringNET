namespace ResumeMaker.API.DTOs.EducationDTOs
{
    public class AddEducationDto
    {
        public int? Id { get; set; }
        public int? TemplateHistoryId { get; set; }
        public string InstitutionTitle { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime DateStart { get; set; }
        public bool CurrentlyStudying { get; set; }
        public DateTime DateEnd { get; set; }
    }
}

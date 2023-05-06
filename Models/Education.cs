namespace ResumeMaker.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
        public string InstitutionTitle { get; set; } = string.Empty;   
        public string Major { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public bool CurrentlyStudying { get; set; }
        public DateTime DateEnd { get; set; }
    }
}

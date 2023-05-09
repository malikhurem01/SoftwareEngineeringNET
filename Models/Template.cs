namespace ResumeMaker.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }        
        public DateOnly DateCreated { get; set; }
        public DateOnly DateUpdated { get; set; }
    }
}

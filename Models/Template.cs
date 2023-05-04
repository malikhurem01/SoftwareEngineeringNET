namespace ResumeMaker.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string HTMLCode { get; set; } = string.Empty;
    }
}

namespace ResumeMaker.Models
{
    public class Language
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}

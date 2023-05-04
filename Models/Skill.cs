namespace ResumeMaker.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
    }
}

namespace ResumeMaker.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public DateTime DateEnd { get; set; }
        public int CVC { get; set; }
    }
}

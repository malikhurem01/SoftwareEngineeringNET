namespace ResumeMaker.API.DTOs.CardDTOs
{
    public class AddCardDto
    {
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int CVC { get; set; }
    }
}

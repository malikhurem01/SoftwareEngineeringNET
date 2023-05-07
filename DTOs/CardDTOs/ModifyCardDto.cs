namespace ResumeMaker.API.DTOs.CardDTOs
{
    public class ModifyCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public DateTime DateEnd { get; set; }
        public int CVC { get; set; }
    }
}

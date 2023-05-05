using ResumeMaker.Models;

namespace ResumeMaker.API.DTOs
{
    public class UserInformationDto
    {
        public List<Education> Education { get; set; } = new List<Education>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Card> Cards { get; set; } = new List<Card>();
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeMaker.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string LinkedInAcc { get; set; } = string.Empty;
        public string GitHubAcc { get; set; } = string.Empty;
        public List<Education> Education { get; set; } = new List<Education>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Card> Cards { get; set; } = new List<Card>();
        public List<Language> Languages { get; set; } = new List<Language>();

    }
}

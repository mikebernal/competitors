using System.Collections.Generic;
namespace competitors.Models
{
    public class Competitor
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string email { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string Website { get; set; }
        public string Photo { get; set; }
        // public ICollection<Game> Games { get; set; }
    }
}
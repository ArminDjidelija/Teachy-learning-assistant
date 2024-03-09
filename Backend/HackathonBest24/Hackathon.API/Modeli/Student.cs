using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }

        [ForeignKey(nameof(Razred))]
        public int RazredId { get; set; }
        public Razred Razred { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class Oblast
    {
        [Key]
        public int Id{ get; set; }
        public string Naziv { get; set; }

        [ForeignKey(nameof(Predmet))]
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }
        public string? SifraFajla { get; set; }
        public string? NazivFajla { get; set; }
    }
}

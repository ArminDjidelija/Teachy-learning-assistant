using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class Odgovor
    {
        [Key]
        public int Id { get; set; }
        public string? Tekst { get; set; }
        public bool Tacan { get; set; }=false;
        public bool IsDeleted { get; set; } = false;

        public string? Esejsko { get; set; }
        [ForeignKey(nameof(Pitanje))]
        public int PitanjeId { get; set; }
        public Pitanje Pitanje { get; set; }

    }
}

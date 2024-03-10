using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class Pitanje
    {
        [Key]
        public int Id { get; set; }
        public string Tekst { get; set; }
        public int BrojBodova { get; set; }
        public bool IsDeleted { get; set; }=false;

        [ForeignKey(nameof(Oblast))]
        public int OblastId { get; set; }
        public Oblast Oblast { get; set; }

        [ForeignKey(nameof(TipPitanja))]
        public int TipPitanjaId { get; set; }
        public TipPitanja TipPitanja { get; set; }

        [ForeignKey(nameof(Profesor))]
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Naziv {  get; set; }
        public bool Aktivan { get; set; }
        public int Trajanje { get; set; }
        public int UkupnoBodova { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool Zavrsen { get; set; } = false;

        public DateTime AktivanDo { get; set; }
        [ForeignKey(nameof(Razred))]
        public int RazredId { get; set; }
        public Razred Razred { get; set; }
        [ForeignKey(nameof(Predmet))]
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }

        [ForeignKey(nameof(Profesor))]
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

    }
}

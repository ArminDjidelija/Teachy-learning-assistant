using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class ProfesoriPredmeti
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Profesor))]
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

        [ForeignKey(nameof(Predmet))]
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }
    }
}

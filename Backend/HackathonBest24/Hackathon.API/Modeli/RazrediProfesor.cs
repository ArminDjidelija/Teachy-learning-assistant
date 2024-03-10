using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class RazrediProfesor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Profesor))]
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

        [ForeignKey(nameof(Razred))]
        public int RazredId { get; set; }
        public Razred Razred { get; set; }

    }
}

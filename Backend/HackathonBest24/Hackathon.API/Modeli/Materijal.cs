using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class Materijal
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }  
        public string Putanja { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey(nameof(Profesor))]
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        [ForeignKey(nameof(Oblast))]
        public int OblastId { get; set; }
        public Oblast Oblast { get; set; }
    }
}

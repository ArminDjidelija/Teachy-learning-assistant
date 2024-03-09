using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class StudentiTestoviOdgovori
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(StudentiTestovi))]
        public int StudentiTestoviId { get; set;}
        public StudentiTestovi StudentiTestovi { get; set; }

        [ForeignKey(nameof(Odgovor))]
        public int? OdgovorId { get; set; }
        public Odgovor Odgovor{ get; set; }

    }
}

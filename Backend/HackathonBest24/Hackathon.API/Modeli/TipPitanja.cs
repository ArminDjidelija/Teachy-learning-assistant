using System.ComponentModel.DataAnnotations;

namespace Hackathon.API.Modeli
{
    public class TipPitanja
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}

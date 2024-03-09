using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class Razred
    {
        public int Id { get; set; }
        public int RazredBroj { get; set; } //npr 6
        public string RazredKlasa { get; set; } //npr a

        [ForeignKey(nameof(TipSkole))]
        public int TipSkoleId { get; set; }
        public TipSkole TipSkole { get; set; }
    }
}

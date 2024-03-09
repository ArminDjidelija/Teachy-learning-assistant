using System.ComponentModel.DataAnnotations;

namespace Hackathon.API.Modeli
{
    public class Predmet
    {
        [Key]
        public int Id{ get; set; }
        public string Naziv { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}

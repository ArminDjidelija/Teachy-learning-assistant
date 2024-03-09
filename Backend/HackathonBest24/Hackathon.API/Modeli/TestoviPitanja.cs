using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class TestoviPitanja
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;


        [ForeignKey(nameof(Test))]
        public int TestId { get; set; }
        public Test Test { get; set; }

        [ForeignKey(nameof(Pitanje))]
        public int PitanjeId { get; set; }
        public Pitanje Pitanje { get; set; }
    }
}

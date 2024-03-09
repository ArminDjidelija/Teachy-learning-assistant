using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Modeli
{
    public class StudentiTestovi
    {
        [Key]
        public int Id { get; set; }
        public int? UkupnoBodova { get; set; } = 0;
        public DateTime DatumPocetka { get; set; }
        public DateTime? DatumZavrsetka { get; set; }
        public bool? Zavrsen { get; set; } = false;

        [ForeignKey(nameof(Test))]
        public int TestId { get; set; }
        public Test Test { get; set; }


        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student{ get; set; }


    }
}

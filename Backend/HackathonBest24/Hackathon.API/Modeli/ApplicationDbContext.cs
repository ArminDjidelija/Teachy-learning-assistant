using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Hackathon.API.Modeli
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Materijal> Materijal { get; set; }
        public DbSet<Oblast> Oblast { get; set; }
        public DbSet<Odgovor> Odgovor { get; set; }
        public DbSet<Pitanje> Pitanje { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<ProfesoriPredmeti> ProfesoriPredmeti { get; set; }
        public DbSet<Razred> Razred { get; set; }
        public DbSet<RazrediProfesor> RazrediProfesor { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentiTestovi> StudentiTestovi { get; set; }
        public DbSet<StudentiTestoviOdgovori> StudentiTestoviOdgovori { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestoviPitanja> TestoviPitanja { get; set; }
        public DbSet<TipPitanja> TipPitanja { get; set; }
        public DbSet<TipSkole> TipSkole { get; set; }

    }
}

using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodaciController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PodaciController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            var tipskole = new List<TipSkole>();
            var tippitanja = new List<TipPitanja>();
            var predmet = new List<Predmet>();
            var profesor = new List<Profesor>();
            var razred = new List<Razred>();
            var student = new List<Student>();
            var profesoripredmet = new List<ProfesoriPredmeti>();

            var razrediprofesor = new List<RazrediProfesor>();
            var test = new List<Test>();
            var oblast = new List<Oblast>();
            var pitanje= new List<Pitanje>();
            var odgovor = new List<Odgovor>();
            var testovipitanja = new List<TestoviPitanja>();
            var studenttestovi = new List<StudentiTestovi>();
            var studentitestoviosgovori = new List<StudentiTestoviOdgovori>();
            var materijal = new List<Materijal>();


            tipskole.Add(new TipSkole { Naziv="Srednja škola"});
            tipskole.Add(new TipSkole { Naziv = "Osnova škola" });

            tippitanja.Add(new TipPitanja { Naziv = "Esejsko pitanje" });
            tippitanja.Add(new TipPitanja { Naziv = "Tacno/Netacno pitanje" });
            tippitanja.Add(new TipPitanja { Naziv = "Više ponuđenih - jedno tačno pitanje" });

            predmet.Add(new Predmet { Naziv = "Biologija" });
            predmet.Add(new Predmet { Naziv = "Muzicka kultura" });
            predmet.Add(new Predmet { Naziv = "Njemacki jezik" });
            predmet.Add(new Predmet { Naziv = "Engleski jezik" });
            predmet.Add(new Predmet { Naziv = "Geografija" });
            predmet.Add(new Predmet { Naziv = "Historija" });
            predmet.Add(new Predmet { Naziv = "Likovna kultura" });
            predmet.Add(new Predmet { Naziv = "Hemija" });
            predmet.Add(new Predmet { Naziv = "Fizika" });
            predmet.Add(new Predmet { Naziv = "Priroda i društvo" });
            predmet.Add(new Predmet { Naziv = "Osnove elektrotehnike" });
            predmet.Add(new Predmet { Naziv = "Digitalna elektronika" });
            predmet.Add(new Predmet { Naziv = "Računarstvo i informatika" });
            predmet.Add(new Predmet { Naziv = "Kompjuterska grafika" });
            predmet.Add(new Predmet { Naziv = "Mašinsko učenje" });

            razred.Add(new Razred { RazredBroj = 1, RazredKlasa = "a", TipSkole = tipskole[0] });
            razred.Add(new Razred { RazredBroj = 2, RazredKlasa = "a", TipSkole = tipskole[0] });
            razred.Add(new Razred { RazredBroj = 3, RazredKlasa = "a", TipSkole = tipskole[0] });
            razred.Add(new Razred { RazredBroj = 4, RazredKlasa = "a", TipSkole = tipskole[0] });
            razred.Add(new Razred { RazredBroj = 6, RazredKlasa = "a", TipSkole = tipskole[1] });
            razred.Add(new Razred { RazredBroj = 7, RazredKlasa = "a", TipSkole = tipskole[1] });
            razred.Add(new Razred { RazredBroj = 8, RazredKlasa = "a", TipSkole = tipskole[1] });
            razred.Add(new Razred { RazredBroj = 9, RazredKlasa = "a", TipSkole = tipskole[1] });

            profesor.Add(new Profesor { Email = "denis@edu.fit.ba", Ime = "Denis", Prezime = "Music",Lozinka="dena" });
            profesor.Add(new Profesor { Email = "adil@edu.fit.ba", Ime = "Adil", Prezime = "Joldic",Lozinka="joldica" });
            profesor.Add(new Profesor { Email = "Jasmin@edu.fit.ba", Ime = "Jasmin", Prezime = "Azemovic",Lozinka="jasko" });
            profesor.Add(new Profesor { Email = "goran@edu.fit.ba", Ime = "Goran", Prezime = "Skondric", Lozinka = "goci" });
            profesor.Add(new Profesor { Email = "edina@edu.fit.ba", Ime = "Edina", Prezime = "Cmanjcanin", Lozinka = "edina" });

            student.Add(new Student { Email = "ensar@edu.fit.ba", Ime = "Ensar", Prezime = "Cevra", Lozinka = "cele", Razred = razred[3] });
            student.Add(new Student { Email = "zaim@edu.fit.ba", Ime = "Zaim", Prezime = "Mehic", Lozinka = "zajke", Razred = razred[3] });
            student.Add(new Student { Email = "nedim@edu.fit.ba", Ime = "Nedim", Prezime = "Mustafic", Lozinka = "neda", Razred = razred[3] });
            student.Add(new Student { Email = "armin@edu.fit.ba", Ime = "Armin", Prezime = "Đidelija", Lozinka = "dido", Razred = razred[3] });
            student.Add(new Student { Email = "adnan@edu.fit.ba", Ime = "Adnan", Prezime = "Humackic", Lozinka = "adnan", Razred = razred[3] });

            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[0], Predmet = predmet[0] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[0], Predmet = predmet[1] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[0], Predmet = predmet[2] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[0], Predmet = predmet[3] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[0], Predmet = predmet[4] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[0], Predmet = predmet[5] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[0], Predmet = predmet[6] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[1], Predmet = predmet[7] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[1], Predmet = predmet[8] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[1], Predmet = predmet[9] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[1], Predmet = predmet[10] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[1], Predmet = predmet[11] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[1], Predmet = predmet[12] });
            profesoripredmet.Add(new ProfesoriPredmeti { Profesor = profesor[1], Predmet = predmet[13] });

            razrediprofesor.Add(new RazrediProfesor { Profesor = profesor[0], Razred = razred[3] });
            razrediprofesor.Add(new RazrediProfesor { Profesor = profesor[1], Razred = razred[0] });
            razrediprofesor.Add(new RazrediProfesor { Profesor = profesor[2], Razred = razred[1] });
            razrediprofesor.Add(new RazrediProfesor { Profesor = profesor[3], Razred = razred[2] });

            //predmet.Add(new Predmet { Naziv = "Biologija" });
            //predmet.Add(new Predmet { Naziv = "Muzicka kultura" });
            //predmet.Add(new Predmet { Naziv = "Njemacki jezik" });
            //predmet.Add(new Predmet { Naziv = "Engleski jezik" });
            //predmet.Add(new Predmet { Naziv = "Geografija" });
            //predmet.Add(new Predmet { Naziv = "Historija" });
            //predmet.Add(new Predmet { Naziv = "Likovna kultura" });

            test.Add(new Test { Naziv = "Test iz predmeta Biologija", Aktivan = true, AktivanDo = DateTime.Now, Predmet = predmet[0], Profesor = profesor[0], Razred = razred[3],Trajanje=2,UkupnoBodova=50});
            test.Add(new Test { Naziv = "Test iz predmeta Muzicka kultura", Aktivan = true, AktivanDo = DateTime.Now, Predmet = predmet[1], Profesor = profesor[0], Razred = razred[3], Trajanje = 2, UkupnoBodova = 50 });
            test.Add(new Test { Naziv = "Test iz predmeta Njemacki jezik", Aktivan = true, AktivanDo = DateTime.Now, Predmet = predmet[2], Profesor = profesor[0], Razred = razred[3], Trajanje = 2, UkupnoBodova = 50 });
            test.Add(new Test { Naziv = "Test iz predmeta Engleski jezik", Aktivan = false, AktivanDo = DateTime.Now, Predmet = predmet[3], Profesor = profesor[0], Razred = razred[3], Trajanje = 2, UkupnoBodova = 50 });
            test.Add(new Test { Naziv = "Test iz predmeta Geografija", Aktivan = false, AktivanDo = DateTime.Now, Predmet = predmet[4], Profesor = profesor[0], Razred = razred[3], Trajanje = 2, UkupnoBodova = 50 });
            test.Add(new Test { Naziv = "Test iz predmeta Historija", Aktivan = false, AktivanDo = DateTime.Now, Predmet = predmet[5], Profesor = profesor[0], Razred = razred[3], Trajanje = 2, UkupnoBodova = 50, Zavrsen = true }); ;
            test.Add(new Test { Naziv = "Test iz predmeta Likovna kultura", Aktivan = false, AktivanDo = DateTime.Now, Predmet = predmet[6], Profesor = profesor[0], Razred = razred[3], Trajanje = 2, UkupnoBodova = 50, Zavrsen = true });

            oblast.Add(new Oblast { Naziv = "Šume", Predmet = predmet[0]});
            oblast.Add(new Oblast { Naziv = "Biljke", Predmet = predmet[0] });
            oblast.Add(new Oblast { Naziv = "Životinje", Predmet = predmet[0] });
            oblast.Add(new Oblast { Naziv = "Bakterije", Predmet = predmet[0] });
            oblast.Add(new Oblast { Naziv = "Virusi", Predmet = predmet[0] });

            oblast.Add(new Oblast { Naziv = "Pjesma", Predmet = predmet[1] });
            oblast.Add(new Oblast { Naziv = "Sonet", Predmet = predmet[1] });
            oblast.Add(new Oblast { Naziv = "Strofa", Predmet = predmet[1] });
            oblast.Add(new Oblast { Naziv = "Stih", Predmet = predmet[1] });


            oblast.Add(new Oblast { Naziv = "Padezi", Predmet = predmet[2] });
            oblast.Add(new Oblast { Naziv = "Akuzativ", Predmet = predmet[2] });
            oblast.Add(new Oblast { Naziv = "Dativ", Predmet = predmet[2] });
            oblast.Add(new Oblast { Naziv = "Ponavljanje", Predmet = predmet[2] });


            oblast.Add(new Oblast { Naziv = "Evropa", Predmet = predmet[4] });
            oblast.Add(new Oblast { Naziv = "Azija", Predmet = predmet[4] });
            oblast.Add(new Oblast { Naziv = "Amerika", Predmet = predmet[4] });
            oblast.Add(new Oblast { Naziv = "Bosna i Hercegovina", Predmet = predmet[4] });

            pitanje.Add(new Pitanje { BrojBodova = 5, Profesor = profesor[0], Oblast = oblast[0] ,Tekst="Koje vrste šume imamo, a koje su zelene zimi?", TipPitanja = tippitanja[2] });
            pitanje.Add(new Pitanje { BrojBodova = 5, Profesor = profesor[0], Oblast = oblast[1], Tekst = "Koja biljka ima crvene listove?", TipPitanja = tippitanja[0] });
            pitanje.Add(new Pitanje { BrojBodova = 5, Profesor = profesor[0], Oblast = oblast[2], Tekst = "Lav je kralj zivotinja?", TipPitanja = tippitanja[1] });
            pitanje.Add(new Pitanje { BrojBodova = 5, Profesor = profesor[0], Oblast = oblast[3], Tekst = "Šta su bakterije?", TipPitanja = tippitanja[0] });
            pitanje.Add(new Pitanje { BrojBodova = 5, Profesor = profesor[0], Oblast = oblast[4], Tekst = "Šta su virusi?", TipPitanja = tippitanja[0] });

            odgovor.Add(new Odgovor { Pitanje = pitanje[0], Tekst = "Zimzelene", Esejsko = null, Tacan = true });
            odgovor.Add(new Odgovor { Pitanje = pitanje[0], Tekst = "Listopadne", Esejsko = null, Tacan = false });
            odgovor.Add(new Odgovor { Pitanje = pitanje[0], Tekst = "Male", Esejsko = null, Tacan = true });
            odgovor.Add(new Odgovor { Pitanje = pitanje[0], Tekst = "Velike", Esejsko = null, Tacan = true });

            odgovor.Add(new Odgovor { Pitanje = pitanje[1], Esejsko = "Ruza", Tacan = true });

            odgovor.Add(new Odgovor { Pitanje = pitanje[2],Tekst="Tacno", Tacan = true });
            odgovor.Add(new Odgovor { Pitanje = pitanje[2],Tekst="Netacno", Tacan = false });

            odgovor.Add(new Odgovor { Pitanje = pitanje[3], Esejsko = "Bakterije su mikroorganizmi", Tacan = true });

            odgovor.Add(new Odgovor { Pitanje = pitanje[4], Esejsko = "Virusi su mikroorganizmi", Tacan = true });

            testovipitanja.Add(new TestoviPitanja { Test = test[0], Pitanje = pitanje[0] });
            testovipitanja.Add(new TestoviPitanja { Test = test[0], Pitanje = pitanje[1] });
            testovipitanja.Add(new TestoviPitanja { Test = test[0], Pitanje = pitanje[2] });
            testovipitanja.Add(new TestoviPitanja { Test = test[0], Pitanje = pitanje[3] });
            testovipitanja.Add(new TestoviPitanja { Test = test[0], Pitanje = pitanje[4] });

            _dbContext.AddRange(tipskole);
            _dbContext.AddRange(tippitanja);
            _dbContext.AddRange(predmet);
            _dbContext.AddRange(profesor);
            _dbContext.AddRange(razred);
            _dbContext.AddRange(student);
            _dbContext.AddRange(profesoripredmet);
            _dbContext.AddRange(razrediprofesor);
            _dbContext.AddRange(test);
            _dbContext.AddRange(oblast);
            _dbContext.AddRange(pitanje);
            _dbContext.AddRange(odgovor);
            _dbContext.AddRange(testovipitanja);

            _dbContext.SaveChanges();



            return Ok();
        }
    }
}

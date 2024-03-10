using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UradeniTestoviPodaciGeneratorController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UradeniTestoviPodaciGeneratorController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> GeneratePodatke()
        {
            var razredi = _applicationDbContext.Razred.Include(x=>x.TipSkole)
                .ToList();
            var profesori=_applicationDbContext.Profesor.
                ToList();
            var predmeti=_applicationDbContext.Predmet
                .ToList();


            var random = new Random();

            var test1 = new Test()
            {
                Aktivan = false,
                AktivanDo=DateTime.Now.AddDays(2),
                Naziv="Neki naziv dodanog testa",
                Trajanje=60,
                RazredId = 4,
                ProfesorId = profesori[random.Next(profesori.Count)].Id,
                PredmetId = 1,
            };
            _applicationDbContext.Test.Add(test1);
            _applicationDbContext.SaveChanges();

            var testDodani1 = _applicationDbContext.Test.Include(x=>x.Profesor).Include(x=>x.Predmet).Include(x=>x.Razred).OrderByDescending(x => x.Id).FirstOrDefault();

            var pitanja = _applicationDbContext.Pitanje.Include(x=>x.Profesor).Include(x=>x.Oblast)
                .Where(x=>x.Oblast.PredmetId==test1.PredmetId).ToList();

            var testoviPitanja = new TestoviPitanja[4];

            for(int i = 0; i < testoviPitanja.Count(); i++)
            {
                testoviPitanja[i] = new TestoviPitanja();
                var rnd = random.Next(pitanja.Count);
                testoviPitanja[i].PitanjeId = pitanja[rnd].Id;
                testoviPitanja[i].TestId = testDodani1.Id;

                var pitanje = _applicationDbContext.Pitanje.Find(testoviPitanja[i].PitanjeId);

                testDodani1.UkupnoBodova += pitanje.BrojBodova;
            }

            foreach(var tp in testoviPitanja)
            {
                _applicationDbContext.TestoviPitanja.Add(tp);
                _applicationDbContext.SaveChanges();
            }

            var studenti = _applicationDbContext.Student.Take(3).ToList();

            var studentiTestovi = new StudentiTestovi[3];

            for(int i = 0; i < studentiTestovi.Count(); i++)
            {
                studentiTestovi[i] = new StudentiTestovi();

                studentiTestovi[i].StudentId = studenti[i].Id;
                studentiTestovi[i].TestId = testDodani1.Id;
                studentiTestovi[i].DatumPocetka = DateTime.Now;
                studentiTestovi[i].DatumZavrsetka = DateTime.Now.AddMinutes(23);

                _applicationDbContext.StudentiTestovi.Add(studentiTestovi[i]);
                _applicationDbContext.SaveChanges();
            }

            var studentiTestoviBaza = _applicationDbContext.StudentiTestovi.Include(x=>x.Test).Include(x=>x.Student).Take(3).OrderByDescending(x => x.Id).ToList();
            var testoviPitanjaBaza = _applicationDbContext.TestoviPitanja.Include(x => x.Pitanje).Include(x => x.Test)
                .Where(x => x.TestId == testDodani1.Id).ToList();
            var odgovoriBaza = _applicationDbContext.Odgovor.Include(x => x.Pitanje).ToList();

            foreach(var stb in studentiTestoviBaza)
            {
                foreach(var p in testoviPitanja)
                {
                    //var odgovori = testoviPitanjaBaza.Where(x => x.PitanjeId == p.PitanjeId && x.TestId==p.TestId).ToList();
                    var odgovori = odgovoriBaza.Where(x => x.PitanjeId == p.PitanjeId).ToList();
                    var stdTestOdg = new StudentiTestoviOdgovori()
                    {
                        StudentiTestoviId = stb.Id,
                        OdgovorId = odgovori[random.Next(odgovori.Count)].Id
                    };

                    _applicationDbContext.StudentiTestoviOdgovori.Add(stdTestOdg);
                    _applicationDbContext.SaveChanges();
                }
            }

            var studentiTestoviBaza1 = _applicationDbContext.StudentiTestovi.Include(x => x.Test).Include(x => x.Student).Take(3).OrderByDescending(x => x.Id).ToList();
            var testoviPitanjaBaza1 = _applicationDbContext.TestoviPitanja.Include(x => x.Pitanje).Include(x => x.Test)
                .Where(x => x.TestId == testDodani1.Id).ToList();

            foreach(var stb in studentiTestoviBaza1)
            {
                var odgPitanjaOdgovori = _applicationDbContext.StudentiTestoviOdgovori.
                    Include(x => x.StudentiTestovi)
                    .Include(x => x.Odgovor)
                    .Where(x => x.StudentiTestoviId == stb.Id).ToList();

                foreach(var opo in odgPitanjaOdgovori)
                {
                    if (opo.Odgovor.Tacan)
                    {
                        stb.UkupnoBodova += opo.Odgovor.Pitanje.BrojBodova;
                    }
                }

                stb.Zavrsen = true;
            }
            _applicationDbContext.SaveChanges();

            return Ok();
        }
    }
}

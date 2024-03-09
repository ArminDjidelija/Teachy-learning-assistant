using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Hackathon.API.Controllers.AiPreporukaOblastiController;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PredmetiController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PredmetiController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery]int studentId)
        {
            var studentiOdgovori = _applicationDbContext.StudentiTestoviOdgovori
               .Include(x => x.StudentiTestovi)
               .Include(x => x.Odgovor)
               .Include(x => x.Odgovor.Pitanje)
               .Include(x => x.Odgovor.Pitanje.Oblast)
               .Where(x=>x.StudentiTestovi.StudentId==studentId)
               .ToList();

            var rezultatiPredmeta = studentiOdgovori
            .GroupBy(so => so.Odgovor.Pitanje.Oblast.PredmetId) // Grupiraj prema PredmetId
            .Select(group => new
            {
                PredmetId = group.Key,
                //NazivPredmeta = group.First().Odgovor.Pitanje.Oblast.Predmet.Naziv, // Dodano polje za naziv predmeta
                ProsjecnaTacnost = group.Average(so => so.Odgovor.Tacan ? 1.0 : 0.0) * 100
            }).ToList();

            var podaci = new List<PredmetiHumaDto>();

            foreach(var rp in rezultatiPredmeta)
            {
                podaci.Add(new PredmetiHumaDto()
                {
                    Predmet = _applicationDbContext.Predmet.Find(rp.PredmetId),
                    Uspjesnost = rp.ProsjecnaTacnost
                });
            }

            return Ok(podaci);
        }


    }

    public class PredmetiHumaDto
    {
        public Predmet Predmet { get; set; }
        public double Uspjesnost { get; set; }
    }
}

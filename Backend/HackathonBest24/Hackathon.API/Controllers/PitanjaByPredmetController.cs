using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PitanjaByPredmetController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PitanjaByPredmetController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var oblasti = await _applicationDbContext.Oblast.Include(x => x.Predmet).ToListAsync();
            var pitanja = _applicationDbContext
                .Pitanje
                .Include(x => x.Oblast).Where(x=>x.IsDeleted==false)
                .ToList();

            var predmeti = _applicationDbContext
                .Predmet
                .ToList();

            var groupedData = pitanja
            .GroupBy(
                p => new { PredmetId = oblasti.First(o => o.Id == p.OblastId).PredmetId, PredmetNaziv = predmeti.First(pr => pr.Id == oblasti.First(o => o.Id == p.OblastId).PredmetId).Naziv },
                (key, group) => new
                {
                    PredmetId = key.PredmetId,
                    PredmetNaziv = key.PredmetNaziv,
                    //OblastNaziv = group.Select(q => new { OblastNaziv = q.Oblast.Naziv }),
                    Pitanja = group.Select(q => new { Id = q.Id, Naziv = q.Tekst, Oblast=q.Oblast.Naziv }).ToArray(),
                })
            .ToArray();

           

            return Ok(groupedData);
        }
    }

    public class PitanjaByPredmetDTO
    {
        public string NazivPredmeta { get; set; }
        public List<Pitanje> Pitanja { get; set; }

    }
}

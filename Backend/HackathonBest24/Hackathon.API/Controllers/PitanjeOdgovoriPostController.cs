using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PitanjeOdgovoriPostController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PitanjeOdgovoriPostController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]PitanjeOdgovoriPostRequest req)
        {
            var novi = new Pitanje()
            {
                BrojBodova = req.BrojBodova,
                OblastId = req.OblastId,
                ProfesorId = req.ProfesorId,
                Tekst = req.Pitanje,
                TipPitanjaId = 3
            };

            _applicationDbContext.Pitanje.Add(novi);
            _applicationDbContext.SaveChanges();

            var pitanjeDodano = _applicationDbContext.Pitanje.OrderByDescending(x => x.Id).FirstOrDefault();

            foreach(var odg in req.Odgovori)
            {
                _applicationDbContext.Add(new Odgovor()
                {
                    PitanjeId = pitanjeDodano.Id,
                    Tekst = odg.Odgovor,
                    Tacan = odg.Tacan,
                });
                _applicationDbContext.SaveChanges();
            }

            return Ok();
        }

    }

    public class PitanjeOdgovoriPostRequest
    {
        public string Pitanje { get; set; }
        public int OblastId { get; set; }
        public List<OdgovorPitanjeDto> Odgovori { get; set; }
        public int BrojBodova { get; set; }
        public int ProfesorId { get; set; }
    }

    public class OdgovorPitanjeDto
    {
        public string Odgovor { get; set; }
        public bool Tacan { get; set; }
    }
}

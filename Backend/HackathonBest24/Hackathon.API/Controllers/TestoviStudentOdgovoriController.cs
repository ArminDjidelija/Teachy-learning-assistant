using Hackathon.API.Helper;
using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Immutable;

namespace Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestoviStudentOdgovoriController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;

        IspraviEsejskoHelper _esejskoHelper = new IspraviEsejskoHelper();
        public TestoviStudentOdgovoriController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromQuery] int teststudentid)
        {
            var lista = _applicationDbContext.StudentiTestoviOdgovori.Include(x => x.Odgovor).ThenInclude(x=>x.Pitanje).Where(x=>x.StudentiTestoviId==teststudentid).ToList();
            int ukupnoBodovi = 0;
            foreach (var item in lista)
            {
                var obj = new IspraviEsejskoDto
                {
                    OdgovorTacan = item.Odgovor.Tekst,
                    OdgovorKorisnik = item.Odgovor.Esejsko,
                    Bodovi = item.Odgovor.Pitanje.BrojBodova,
                    Pitanje = item.Odgovor.Pitanje.Tekst

                };

                var brojBodova = await _esejskoHelper.IspraviEsejsko(_configuration, obj);
                ukupnoBodovi += brojBodova;
            }

            return Ok(ukupnoBodovi);
        }
    }
}

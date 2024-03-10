using Hackathon.API.Helper;
using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
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
            var listaDto = new List<IspraviEsejskoDto>();
            var lista = _applicationDbContext.StudentiTestoviOdgovori.Include(x => x.Odgovor).ThenInclude(x=>x.Pitanje).Where(x=>x.StudentiTestoviId==teststudentid).ToList();
            int ukupnoBodovi = 0;
            int bodoviBezParc = 0;
            foreach (var item in lista)
            {

                if(!item.Odgovor.Esejsko.IsNullOrEmpty())
                {
                    var obj2 = new IspraviEsejskoDto
                    {
                        OdgovorTacan = item.Odgovor.Tekst,
                        OdgovorKorisnik = item.Odgovor.Esejsko,
                        Bodovi = item.Odgovor.Pitanje.BrojBodova,
                        Pitanje = item.Odgovor.Pitanje.Tekst,

                    };
                    listaDto.Add(obj2);
                }
                else
                {
                    if(item.Odgovor.Tacan==true)
                    {
                        bodoviBezParc += item.Odgovor.Pitanje.BrojBodova;
                    }
                }


            }
            ukupnoBodovi= _esejskoHelper.IspraviEsejsko(_configuration, listaDto).Result.Sum()+bodoviBezParc;
            var obj = _applicationDbContext.StudentiTestovi.Where(x => x.Id == teststudentid).FirstOrDefault();
            obj.OsvojeniBodovi = ukupnoBodovi;
            _applicationDbContext.Update(obj);
            _applicationDbContext.SaveChanges();
            return Ok(ukupnoBodovi);
        }
    }
}

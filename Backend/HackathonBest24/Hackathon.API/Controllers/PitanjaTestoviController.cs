using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PitanjaTestoviController : ControllerBase
    {

        private readonly ApplicationDbContext _applicationDbContext;
        public PitanjaTestoviController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostPitanjaTestovi request)
        {
            var obj = new TestoviPitanja
            {
                PitanjeId = request.PitanjeId,
                TestId = request.TestId
            };

            var test = _applicationDbContext.Test.Where(x=>x.Id==request.TestId).FirstOrDefault();
            var pitanje=_applicationDbContext.Pitanje.Where(x=>x.Id==request.PitanjeId).FirstOrDefault();
            if(test!=null && pitanje!=null)
            {
                test.UkupnoBodova += pitanje!.BrojBodova;
            }

            _applicationDbContext.Add(obj);
            _applicationDbContext.SaveChanges();

            return Ok(obj);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            var pitanja = await _applicationDbContext.TestoviPitanja.Include(x => x.Pitanje).Where(x => x.TestId == id && x.IsDeleted==false).Select(x => new
            {
                Tekst = x.Pitanje.Tekst,
                Id = x.Id
            }).ToListAsync();

            if (pitanja != null)
                return Ok(pitanja);
            else
                return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var obj = await _applicationDbContext.TestoviPitanja.Where(x=>x.Id==id).FirstOrDefaultAsync();

            obj.IsDeleted = true;
            _applicationDbContext.Update(obj);
            _applicationDbContext.SaveChanges();
            return Ok();
        }
    }

    public class PostPitanjaTestovi
    {
        public int PitanjeId { get; set; }
        public int TestId { get; set; }
    }
}


    




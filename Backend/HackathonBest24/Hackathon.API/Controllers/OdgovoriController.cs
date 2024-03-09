using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OdgovoriController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OdgovoriController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]OdgovorPostRequest odgovorPostRequest)
        {
            var novi = new Odgovor()
            {
                Esejsko = odgovorPostRequest.Esejsko,
                PitanjeId = odgovorPostRequest.PitanjeId,
                Tacan = odgovorPostRequest.Tacan,
                Tekst = odgovorPostRequest.Tekst
            };

            _applicationDbContext.Odgovor.Add(novi);
            _applicationDbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var obj = _applicationDbContext.Odgovor.Where(x=>x.Id == id).FirstOrDefault();
            obj.IsDeleted = true;

            _applicationDbContext.Update(obj);
            _applicationDbContext.SaveChanges();



            return Ok();
        }
    }

    public class OdgovorPostRequest
    {
        public string? Tekst { get; set; }
        public bool Tacan { get; set; } = false;

        public string? Esejsko { get; set; }

        public int PitanjeId { get; set; }
    }
}

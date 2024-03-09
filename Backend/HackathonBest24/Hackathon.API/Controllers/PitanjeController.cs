using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PitanjeController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PitanjeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PitanjePostRequest pitanjePostRequest)
        {
            var novo = new Pitanje()
            {
                BrojBodova = pitanjePostRequest.BrojBodova,
                OblastId = pitanjePostRequest.OblastId,
                ProfesorId = pitanjePostRequest.ProfesorId,
                Tekst = pitanjePostRequest.Tekst,
                TipPitanjaId = pitanjePostRequest.TipPitanjaId,
            };

            _applicationDbContext.Pitanje.Add(novo);
            _applicationDbContext.SaveChanges();

            return Ok();
        }
    }

    public class PitanjePostRequest
    {
        public string Tekst { get; set; }
        public int BrojBodova { get; set; }

        public int OblastId { get; set; }

        public int TipPitanjaId { get; set; }

        public int ProfesorId { get; set; }

    }
}

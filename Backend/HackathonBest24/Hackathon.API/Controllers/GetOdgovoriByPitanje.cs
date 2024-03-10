using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetOdgovoriByPitanje : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetOdgovoriByPitanje(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int pitanjeId)
        {
            var odgovori = _applicationDbContext.Odgovor.Where(x => x.PitanjeId == pitanjeId).ToListAsync();
            if(odgovori!=null)
            {
                return Ok(odgovori);
            }
            else { return NotFound(); }
        }
    }
}

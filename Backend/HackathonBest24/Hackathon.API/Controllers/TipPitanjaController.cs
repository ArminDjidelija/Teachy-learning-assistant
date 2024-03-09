using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipPitanjaController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TipPitanjaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var tipovi = await _applicationDbContext.TipPitanja.ToListAsync();

            if(tipovi != null) {
            return Ok(tipovi);}
            else
            {
                return NoContent();
            }
        }
    }
}

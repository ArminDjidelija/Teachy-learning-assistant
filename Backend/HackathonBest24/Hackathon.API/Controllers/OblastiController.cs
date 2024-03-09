using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OblastiController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OblastiController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllByPredmet([FromQuery] int id)
        {
            var oblasti = await _applicationDbContext.Oblast.Where(x=>x.PredmetId==id).ToListAsync();

            if(oblasti!=null)
            {
                return Ok(oblasti);
            }
            return NotFound();
        }
    }
}

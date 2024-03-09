using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PredmetiController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PredmetiController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var predmeti = _applicationDbContext
                .Predmet
                .OrderBy(x=>x.Naziv)
                .ToList();

            return Ok(predmeti);
        }


    }
}

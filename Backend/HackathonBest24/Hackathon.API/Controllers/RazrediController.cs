using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RazrediController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RazrediController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var profesor = _applicationDbContext.Profesor.FirstOrDefault();
            var razredi = _applicationDbContext
                .Razred
                .Where(x=>)
                .ToList();


            return Ok(razredi);
        }
    }
}

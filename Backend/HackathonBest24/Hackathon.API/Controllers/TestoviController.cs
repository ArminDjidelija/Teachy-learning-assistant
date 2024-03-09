using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestoviController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TestoviController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var profesor=_applicationDbContext.Profesor.First();

            if (profesor != null)
            {
                var testovi=_applicationDbContext
                    .Test
                    .Include(x=>x.Predmet)
                    .Include(x=>x.Profesor)
                    .Include(x=>x.Razred)
                    .Where(x=>x.ProfesorId  == profesor.Id)
                    .ToList();

                return Ok(testovi);
            }

            return Ok();
        }
    }
}

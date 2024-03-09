using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetPredmetiByProfesorController : ControllerBase
    {

        private readonly ApplicationDbContext _applicationDbContext;
        public GetPredmetiByProfesorController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetByProfesorId([FromQuery] int profesorId)
        {
            var podaci = await _applicationDbContext
                .ProfesoriPredmeti
                .Include(x => x.Predmet)
                .Include(x => x.Profesor)
                .Where(x => x.ProfesorId == profesorId)
                .ToListAsync();

            var predmeti = new List<Predmet>();
            foreach (var predmet in podaci) { predmeti.Add(predmet.Predmet); }

            return Ok(predmeti);
        }
    }
}

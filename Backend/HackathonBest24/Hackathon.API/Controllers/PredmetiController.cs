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
                .ToList();

            return Ok(predmeti);
        }

        [HttpGet("{profesorId}")]
        public async Task<ActionResult> GetByProfesorId([FromRoute]int profesorId)
        {
            var podaci=_applicationDbContext
                .ProfesoriPredmeti
                .Include(x=>x.Predmet)
                .Include(x=>x.Profesor)
                .Where(x=>x.ProfesorId==profesorId)
                .ToList();

            var predmeti = new List<Predmet>();
            foreach(var predmet in podaci) { predmeti.Add(predmet.Predmet); }

            return Ok(predmeti);
        }
    }
}

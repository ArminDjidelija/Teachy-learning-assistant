using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var profesoriRazredi = new List<RazrediProfesor>();

            if (profesor != null)
            {
                profesoriRazredi = _applicationDbContext
                .RazrediProfesor
                .Include(x => x.Profesor)
                .Include(x => x.Razred)
                .Where(x => x.ProfesorId == profesor.Id)
                .ToList();
            }

            var razredi = new List<Razred>();

            foreach(var prof in profesoriRazredi)
            {
                razredi.Add(prof.Razred);
            }


            return Ok(razredi);
        }

        [HttpGet("byProfesor")]
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            var razredi = _applicationDbContext.RazrediProfesor.Include(x=>x.Razred).Where(x=>x.ProfesorId==id).Select(x=>new
            {
                Naziv=x.Razred.RazredBroj + "-" + x.Razred.RazredKlasa,
                BrojUcenika = _applicationDbContext.Student.Where(y=>y.RazredId==x.RazredId).Count()
            }).ToList();


            return Ok(razredi);
        }
    }
}

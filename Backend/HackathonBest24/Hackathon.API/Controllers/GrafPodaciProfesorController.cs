using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GrafPodaciProfesorController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GrafPodaciProfesorController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetPodaciGraf([FromQuery] int profesorId)
        {
            var studentTestovi = _applicationDbContext.StudentiTestovi
                .Include(x => x.Student)
                .Include(x => x.Test)
                .Where(x => x.Test.ProfesorId == profesorId)
                .ToList();

            var rezultatiTestova = studentTestovi
                       .GroupBy(st => st.Test)
                       .Select(group => new
                       {
                           TestId = group.Key,
                           BrojStudenata = group.Count(),
                           ProsječnaProlaznost = Math.Round(group.Count(st => (double)st.UkupnoBodova / st.UkupnoBodova > 0.4) / (double)group.Count() * 100, 1)
                       });

            return Ok(rezultatiTestova);
        }
    }
}

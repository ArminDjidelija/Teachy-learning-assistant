using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodaciController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PodaciController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult Generisi()
        {
            var tipskole = new List<TipSkole>();
            var tippitanja = new List<TipPitanja>();
            var predmet = new List<Predmet>();
            var profesor = new List<Profesor>();
            var student = new List<Student>();
            var profesoripredmet = new List<ProfesoriPredmeti>();
            var test = new List<Test>();
            var oblast = new List<Oblast>();
            var pitanje= new List<Pitanje>();
            var odgovor = new List<Odgovor>();
            var testovipitanja = new List<TestoviPitanja>();
            var studenttestovi = new List<StudentiTestovi>();
            var studentitestoviosgovori = new List<StudentiTestoviOdgovori>();
            var razred = new List<Razred>();
            var razrediprofesor = new List<RazrediProfesor>();

            return Ok();
        }
    }
}

using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestoviStudentController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TestoviStudentController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var student=_applicationDbContext.Student.First();

            if (student != null)
            {
                var testovi=_applicationDbContext
                    .Test
                    .Include(x=>x.Predmet)
                    .Include(x=>x.Profesor)
                    .Where(x=>x.RazredId==student.RazredId)
                    .ToList();

                return Ok(testovi);
            }

            return Ok();
        }
    }
}

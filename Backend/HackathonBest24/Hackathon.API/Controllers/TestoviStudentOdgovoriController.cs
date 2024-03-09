using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Immutable;

namespace Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestoviStudentOdgovoriController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TestoviStudentOdgovoriController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromQuery] int teststudentid)
        {
            var lista = _applicationDbContext.StudentiTestoviOdgovori.Include(x => x.Odgovor).Where(x=>x.StudentiTestoviId==teststudentid).ToList();

            if(lista!=null)
            {
                return Ok(lista);
            }
            return NotFound();
        }
    }
}

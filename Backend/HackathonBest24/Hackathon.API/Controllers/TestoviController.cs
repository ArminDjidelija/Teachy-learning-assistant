using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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
                    .Where(x=>x.ProfesorId  == profesor.Id && x.IsDeleted==false)
                    .ToList();

                return Ok(testovi);
            }

            return Ok();
        }

        [HttpGet("getzavrseni")]
        public async Task<ActionResult> GetZavrseni([FromQuery] int studentID)
        {
            var student = await _applicationDbContext.Student.FindAsync(studentID);

            if (student != null)
            {
                var testovi = _applicationDbContext
                    .StudentiTestovi
                    .Include(x => x.Student)
                    .Include(x => x.Test)
                    .Include(x=>x.Test.Predmet)
                    .Where(x => x.Zavrsen==true && x.StudentId == student.Id)
                    .ToList();

                return Ok(testovi);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InsertTestVM request)
        {
            var obj = new Test
            {
                Aktivan = false,
                AktivanDo = request.AktivanDo,
                Naziv = request.Naziv,
                PredmetId = request.PredmetId,
                ProfesorId = request.ProfesorId,
                RazredId = request.RazredId,
                Trajanje = request.Trajanje,
                UkupnoBodova = 0,
                IsDeleted = false

            };

            _applicationDbContext.Add(obj);
            _applicationDbContext.SaveChanges();

            return Ok(obj);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var obj = _applicationDbContext.Test.Where(x=>x.Id==id).FirstOrDefault();
            if (obj == null)
                return BadRequest();
            else
            {
                obj.IsDeleted = true;
                _applicationDbContext.SaveChanges();
            }

            return Ok();
        }
    }

    public class InsertTestVM
    {
        public string Naziv { get; set; }
        public int Trajanje { get; set; }
        public DateTime AktivanDo { get; set; }
        public int RazredId { get; set; }
        public int PredmetId { get; set; }
        public int ProfesorId { get; set; }
    
    }


}

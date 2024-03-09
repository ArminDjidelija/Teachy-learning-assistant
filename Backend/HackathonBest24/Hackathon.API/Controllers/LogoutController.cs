using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public LogoutController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Logout([FromBody]LogoutRequest logoutRequest)
        {
            if (logoutRequest == null)
                return BadRequest();

            if (logoutRequest.Uloga.ToLower()=="profesor") {
                var profesor = _applicationDbContext.Profesor.Find(logoutRequest.Id);
                profesor.Logiran = false;
                _applicationDbContext.SaveChanges();
                return Ok();
            }
            else if(logoutRequest.Uloga.ToLower() == "student")
            {
                var student = _applicationDbContext.Student.Find(logoutRequest.Id);
                student.Logiran = false;
                _applicationDbContext.SaveChanges();
                return Ok();
            }

            return BadRequest("Pogresna uloga ili id");
        }
    }

    public class LogoutRequest
    {
        public int Id { get; set; }
        public string Uloga { get; set; }
    }
}

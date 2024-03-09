using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public LoginController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginRequest loginRequest)
        {
            var studentFound = _applicationDbContext
                .Student.Where(x => x.Email == loginRequest.Email && x.Lozinka == loginRequest.Lozinka)
                .FirstOrDefault();

            var profesorFound= _applicationDbContext
                .Profesor.Where(x => x.Email == loginRequest.Email && x.Lozinka == loginRequest.Lozinka)
                .FirstOrDefault();

            if(studentFound == null && profesorFound==null) {
                return Unauthorized("Pogrešni kredencijali");
            }

            if (studentFound != null)
            {
                studentFound.Logiran = true;
            }
            else if (profesorFound != null)
            {
                profesorFound.Logiran = true;
            }
            return Ok();
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Lozinka { get; set; }
    }
}

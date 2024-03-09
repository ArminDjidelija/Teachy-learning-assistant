using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaterijalOblastController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public MaterijalOblastController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }



    }

    public class AddSlikaBody
    {
        public IFormFile Slika { get; set; }
        public string Id { get; set; }

    }
}

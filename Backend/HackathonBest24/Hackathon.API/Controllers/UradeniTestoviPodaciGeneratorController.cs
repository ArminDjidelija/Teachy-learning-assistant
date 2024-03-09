using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UradeniTestoviPodaciGeneratorController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UradeniTestoviPodaciGeneratorController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}

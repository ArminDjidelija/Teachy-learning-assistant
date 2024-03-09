using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OblastController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _environment;

        public OblastController(ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _applicationDbContext = applicationDbContext;
            _environment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult> GetMaterijali([FromQuery]OblastGetDto request)
        {
            var podaci=_applicationDbContext
                .Oblast
                .Where(x=>x.PredmetId==request.PredmetId)
                .Select(x =>new OblastResponse
                {
                    Predmet=x.Predmet,
                    Oblast=x,
                    FileUrl= GetFileByPredmet(x.NazivFajla, _environment)
                }).ToList();

            return Ok(podaci);
        }
        private static string GetFileByPredmet(string path, IWebHostEnvironment env)
        {
            string imageUrl = string.Empty;
            string HostUrl = "https://localhost:7020";
            string filepath = GetFilePath(path, env);
            if (!System.IO.File.Exists(filepath))
            {
                imageUrl = "";
            }
            else
            {
                imageUrl = HostUrl + "/Fajlovi/Materijali/" + path;
            }

            return imageUrl;
        }

        private static string GetFilePath(string productCode, IWebHostEnvironment env)
        {
            return env.WebRootPath + "\\Fajlovi\\Materijali\\" + productCode;
        }
    }

 
    public class OblastGetDto
    {
        public int PredmetId { get; set; }
    }

    public class OblastResponse
    {
        public Predmet Predmet { get; set; }
        public Oblast Oblast { get; set; }
        public string FileUrl { get; set; }
    }
}

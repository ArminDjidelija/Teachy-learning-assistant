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
        private readonly IWebHostEnvironment _environment;

        public MaterijalOblastController(ApplicationDbContext applicationDbContext, IWebHostEnvironment environment)
        {
            _applicationDbContext = applicationDbContext;
            _environment = environment;
        }

        [HttpPost]
        public async Task<ActionResult> PostFile([FromForm]AddSlikaBody obj)
        {

            if (obj.File != null)
            {
                string projekatFolder1 = Environment.CurrentDirectory;

                //string projekatFOlder2 = Directory.GetParent(projekatFolder1).Parent.FullName;

                //string projekatFolder3 = Directory.GetParent(projekatFolder1).Parent.Parent.FullName;

                //string wwwRootPath = _webHostEnvironment.WebRootPath;
                string orginalniNaziv=obj.File.FileName;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.File.FileName);
                string envFile = _environment.WebRootPath + "\\Fajlovi\\Materijali\\" + fileName;

                // string productWithPath = Path.Combine(productPath, fileName);
                // string productPath=Path.Combine(folderPath, @"\Slike\Proizvodi");
                using (Stream fileStream = new FileStream(envFile, FileMode.Create))
                {
                    obj.File.CopyTo(fileStream);
                }

                var oblast = _applicationDbContext.Oblast.Find(int.Parse(obj.Id));
                if (oblast != null)
                {
                    oblast.NazivFajla = orginalniNaziv;
                    oblast.SifraFajla = fileName;
                }

                _applicationDbContext.SaveChanges();
                return Ok("Uspjesno spasen fajl!");

            }

            return BadRequest("Neki problem je bio");
        }

    }

    public class AddSlikaBody
    {
        public IFormFile File { get; set; }
        public string Id { get; set; }

    }
}

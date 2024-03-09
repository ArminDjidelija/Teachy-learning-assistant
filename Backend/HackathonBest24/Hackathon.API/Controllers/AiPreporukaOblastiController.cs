using Hackathon.API.Helper;
using Hackathon.API.Modeli;
using iText.Commons.Bouncycastle.Cert.Ocsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenAI_API;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AiPreporukaOblastiController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public AiPreporukaOblastiController(ApplicationDbContext applicationDbContext, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult> GetPreporuka()
        {
            var studentiOdgovori = _applicationDbContext.StudentiTestoviOdgovori
                .Include(x => x.StudentiTestovi)
                .Include(x => x.Odgovor)
                .Include(x => x.Odgovor.Pitanje)
                .Include(x => x.Odgovor.Pitanje.Oblast)
                .ToList();

            var rezultatiOblasti = studentiOdgovori
           .GroupBy(so => so.Odgovor.Pitanje.Oblast.Id) // Grupiraj prema PredmetId oblasti
           .Select(group => new NoviPodatakDto
           {
               OblastId = group.Key,
               OblastName = group.First().Odgovor.Pitanje.Oblast.Naziv,
               ProsjecnaTacnost = group.Average(so => so.Odgovor.Tacan ? 1.0 : 0.0) * 100,
           });

            

            var rezultatiObradjeni = rezultatiOblasti.OrderBy(x => x.ProsjecnaTacnost).ToList();

            foreach (var obj in rezultatiObradjeni)
            {
                var oblastId = obj.OblastId;
                var oblastObj = _applicationDbContext.Oblast.Find(oblastId);
                var oblastFileUrl = PdfToWord.GetFileOnline(oblastObj.SifraFajla, _environment);
                obj.FileUrl = oblastFileUrl;
            }

            string openaiKey = _configuration.GetValue<string>("OpenAi:Key");
            var openAi = new OpenAIAPI(new APIAuthentication(openaiKey));
            var conversation = openAi.Chat.CreateConversation();

            var prolaznost = "";

            foreach (var pr in rezultatiObradjeni)
            {
                prolaznost += $"{pr.OblastName} ima {pr.ProsjecnaTacnost}% tačnih odgovora. " +
                    $"";
            }

            var requestGpt = $"Ti si pametni personalni savjetnik u skolstvu. " +
                             $"Ovo su podaci o oblastima i procenat tačno odgovorenih odgovora: " +
                             $"{prolaznost}." +
                             $"Napiši mi personalnu poruku savjeta nastavniku koji ovo radi i predaje";



            conversation.AppendUserInput(requestGpt);
            var response = await conversation.GetResponseFromChatbotAsync();

            response = response.Replace("\n", "");

            return Ok(new PreporukaDto()
            {
                Podaci = rezultatiObradjeni,
                Poruka = response
            });
        }
        public class PreporukaDto
        {
            public List<NoviPodatakDto> Podaci { get; set; }
            public string Poruka { get; set; }
        }

        public class NoviPodatakDto
        {
            public int OblastId { get; set; }
            public string OblastName { get; set; }
            public double ProsjecnaTacnost { get; set; }
            public string FileUrl { get; set; }
        }
    }

}

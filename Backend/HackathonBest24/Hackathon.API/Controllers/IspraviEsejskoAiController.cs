using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IspraviEsejskoAiController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public IspraviEsejskoAiController(ApplicationDbContext applicationDbContext, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
            _environment = environment;
        }

        [HttpPost]
        public async Task<ActionResult> Ispravi([FromBody]IspraviEsejskoDto req)
        {
            string openaiKey = _configuration.GetValue<string>("OpenAi:Key");
            var openAi = new OpenAIAPI(new APIAuthentication(openaiKey));
            var conversation = openAi.Chat.CreateConversation();

            var requestGpt = $"Ti si pametni personalni profesor koji treba da ispravi pitanje i ocijeni realno. " +
                             $"Dat cu ti pitanje od profesora, odgovor od profesora, odgovor od studenta i broj bodova pitanja" +
                             $"Onda mi ti trebas realno bodovati taj odgovor studenta, na osnovu njegovog odgovora" +
                             $"Ovo je pitanje: {req.Pitanje}." +
                             $"Ovo je odgovor profesora, odnosno tačni odgovor: {req.OdgovorTacan}. " +
                             $"Ovo je odgovor studenta koji trebaš odgovoriti: {req.OdgovorKorisnik}. " +
                             $"Broj bodova pitanja je {req.Bodovi}" +
                             $"Trebaš mi samo vratiti u broju broj bodova koje bi mu ti dao, znaci samo broj bez tacke, bez icega." +
                             $"Ocjenjuj realno, odnosno korisnik ne mora reći u potpunosti isto, već samo da je tačno. " +
                             $"Može student i proširiti i skratiti svoj odgovor, ali ako se vidi da student razmije definiciju daj mu sve bodove. " +
                             $"Ako ima greške skini mu shodno bodove";



            conversation.AppendUserInput(requestGpt);
            var response = await conversation.GetResponseFromChatbotAsync();

            var bodovi = int.Parse(response);

            return Ok(new ResponseIspraviEsejsko() { Bodovi=bodovi});
        }

    }

    public class IspraviEsejskoDto
    {
        public string Pitanje { get; set; }
        public string OdgovorTacan { get; set; }
        public string OdgovorKorisnik { get; set; }
        public int Bodovi { get; set; }
    }

    public class ResponseIspraviEsejsko
    {
        public int Bodovi { get; set; }
    }
}

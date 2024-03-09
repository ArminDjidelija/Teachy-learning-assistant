using Azure.Core;
using Hackathon.API.Helper;
using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OpenAI_API;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AiPitanjaGeneratorController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public AiPitanjaGeneratorController(ApplicationDbContext applicationDbContext, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult> GetPitanja([FromQuery]GenerateAiPitanjaDTO req)
        {
            string openaiKey = _configuration.GetValue<string>("OpenAi:Key");
            var openAi = new OpenAIAPI(new APIAuthentication(openaiKey));
            var conversation = openAi.Chat.CreateConversation();

            var oblast=_applicationDbContext.Oblast.Find(req.OblastId);

            var fileUrl = PdfToWord.GetFileByPredmet(oblast.SifraFajla, _environment);

            var oblastPdf = PdfToWord.ConvertToString(oblast.SifraFajla, _environment);

            var requestGpt = $"Ti si nastavnik koji kreira test i pitanja. " +
                             $"Ovo u navodnicima malim je materijal: '{oblastPdf}'. " +
                             $"Kreiraj {req.BrojPitanja} iz materijala koji sam ti poslao za oblast id: {req.OblastId}, i " +
                             $"daj mi nekoliko ponuđenih odgovora za svako pitanje gdje je samo jedan odgovor tačan. " +
                             $"Vrati mi u formatu json, tako da imas niz objekata sa objetkima, a svaki clan niza ima: " +
                             $"pitanje: koje ima id, tekst, brojBodova, oblastId koju sam ti dao, tipPitanjaId je 3 uvijek, i onda niz odgovora ovako:" +
                             $"Pitanje ima niz odgovori:[] gdje svaki odgovor ima tekst (tu napisi ponudjeni odgovor), tacan (bool, moze samo jedan odgovor biti tacan), " +
                             $"Znaci vracas u formatu niza, gdje svaki clan niza ima pitanje i odgovori[]. " +
                             $"Znaci sve je u nizu, onda ide objekat " +
                             $"Vrati mi bas cijeli string kao u formatu tako da mogu uraditi direktno deserijalizaciju u svoje klase";



            conversation.AppendUserInput(requestGpt);
            var response = await conversation.GetResponseFromChatbotAsync();

            //string bezPrveIZadnjeLinije = UkloniPrvuIZadnjuLiniju(response);


            var podaci = JsonConvert.DeserializeObject<JsonPodaciGpt[]>(response);

            return Ok(podaci);
        }
        static string UkloniPrvuIZadnjuLiniju(string ulazniString)
        {
            // Razdvoji string na linije
            string[] linije = ulazniString.Split('\n');

            // Ukloni prvu i zadnju liniju
            if (linije.Length >= 3) // Provjeri ima li barem tri linije (prva, srednja, zadnja)
            {
                return string.Join("\n", linije, 1, linije.Length - 2);
            }
            else
            {
                // Ako nema dovoljno linija, vrati prazan string ili originalni string ovisno o potrebama
                return string.Empty;
            }
        }
    }
    public class GenerateAiPitanjaDTO
    {
        public int OblastId { get; set; }
        public int BrojPitanja { get; set; }
    }

    public class JsonPodaciGpt
    {
        public PitanjaDTO pitanje { get; set; }
        public List<Odgovor> odgovori { get; set; }
    }

    public class JsonDtoPitanjaOdgovori
    {
        public PitanjaDTO Pitanja { get; set; }
        public List<OdgovorDto> Odgovori { get; set; }
    }
    public class PitanjaDTO
    {
        public string tekst { get; set; }
        public int brojBodova { get; set; }
        public int oblastId { get; set; }
        public int tipPitanjaId { get; set; }

    }
    public class OdgovorDto
    {
        public string tekst { get; set; }
        public bool tacan { get; set; }
    }
}

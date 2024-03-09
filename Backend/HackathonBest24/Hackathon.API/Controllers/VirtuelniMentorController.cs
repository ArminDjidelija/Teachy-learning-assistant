using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OpenAI_API;

namespace Hackathon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VirtuelniMentorController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public VirtuelniMentorController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]VirtuelniMentorRequest request)
        {
            string openaiKey = _configuration.GetValue<string>("OpenAi:Key");
            var openAi = new OpenAIAPI(new APIAuthentication(openaiKey));
            var conversation = openAi.Chat.CreateConversation();

            var requestGpt = $"Zamisli da si skolski nastavnik koji odgovara ucenicima na pitanja. " +
                        $"Odgovaraj samo na pitanja vezana za skolu i nastavu, a ostala nemoj dozvoliti niti odgovarati. " +
                        $"Ovo je request koji salje moj korisnik preko apija: {request.Request} " +
                        $"Zavrsilo je ono sto ti je korisnik slao. " +
                        $"Odgovaraj u zanimljivoj formi, i nemoj prevelike odgovore osim ako to korisnik ne zahtijeva od tebe suprotno.";

            conversation.AppendUserInput(requestGpt);
            var response = await conversation.GetResponseFromChatbotAsync();

            return Ok(new VirtuelniMentorResponse()
            {
                Response=response
            });
        }
    }

    public class VirtuelniMentorRequest
    {
        public string Request { get; set; }
    }
    public class VirtuelniMentorResponse
    {
        public string Response { get; set; }
    }
}

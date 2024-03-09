using Hackathon.API.Controllers;
using iText.Commons.Bouncycastle.Cert.Ocsp;
using OpenAI_API;

namespace Hackathon.API.Helper
{
    public class IspraviEsejskoHelper
    {
        public IspraviEsejskoHelper()
        {
            
        }
        public async Task<int[]> IspraviEsejsko(IConfiguration configuration, List<IspraviEsejskoDto> requests)
        {
            string openaiKey = configuration.GetValue<string>("OpenAi:Key");
            var openAi = new OpenAIAPI(new APIAuthentication(openaiKey));
            var conversation = openAi.Chat.CreateConversation();


            var requestGpt = "";
            foreach (var req in requests)
            {
                requestGpt += $"Ti si pametni personalni profesor koji treba da ispravi pitanje i ocijeni realno. " +
                             $"Dat cu ti pitanje od profesora, odgovor od profesora, odgovor od studenta i broj bodova pitanja" +
                             $"Onda mi ti trebas realno bodovati taj odgovor studenta, na osnovu njegovog odgovora" +
            $"Ovo je pitanje: {req.Pitanje}." +
            $"Ovo je odgovor profesora, odnosno tačni odgovor: {req.OdgovorTacan}. " +
                             $"Ovo je odgovor studenta koji trebaš odgovoriti: {req.OdgovorKorisnik}. " +
                             $"Broj bodova pitanja je {req.Bodovi}" +
                             $"Trebaš mi samo vratiti u broju broj bodova koje bi mu ti dao, znaci samo broj bez tacke, bez icega." +
                             $"Ocjenjuj realno, odnosno korisnik ne mora reći u potpunosti isto, već samo da je tačno. " +
                             $"Može student i proširiti i skratiti svoj odgovor, ali ako se vidi da student razmije definiciju daj mu sve bodove. " +
                             $"Ako ima greške skini mu shodno bodove" +
                             $"";
            }

            requestGpt += "Podatke mi vrati u formatu csv, odnosno: prvo pitanje bodovi, drugo pitanje bodovi, trece pitanje bodovi itd po potrebi (npr ovako 1,2,3,2,2)";

           


            conversation.AppendUserInput(requestGpt);
            var response = await conversation.GetResponseFromChatbotAsync();

            string[] stringArray = response.Split(',');

            // Prolazimo kroz svaki dio stringArray-a i pretvaramo ga u int
            int[] intArray = Array.ConvertAll(stringArray, int.Parse);



            return intArray;
        }
    }
}

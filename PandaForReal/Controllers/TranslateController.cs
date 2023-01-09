using Microsoft.AspNetCore.Mvc;
using PandaForReal.Models;


namespace PandaForReal.Controllers
{
    public class TranslateController : ControllerBase
    {
        private  HttpClient client = new HttpClient();

        public TranslateController()
        {

        }


        [HttpGet("languages")]
        public async Task<ActionResult<string>>GetLanguagues()
        {          
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2/languages"),
                Headers =
    {
        { "X-RapidAPI-Key", "a8f7f24208msh31f0072109944e4p1bb5b5jsneab9b2e0cdd2" },
        { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var rv = await response.Content.ReadFromJsonAsync<LanguagesModel>();
               if(rv == null) {
                return BadRequest("Coudnt get Languages");
               }
                return Ok(rv.data.languages);    
            }
        }

        [HttpPost("Translate")]
        public async Task<ActionResult<Translate>> Translate(string sentence , string targetLang , string sourceLang)
        {
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
    {
        { "X-RapidAPI-Key", "a8f7f24208msh31f0072109944e4p1bb5b5jsneab9b2e0cdd2" },
        { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "q", sentence },
        { "target", targetLang },
        { "source", sourceLang },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var rv= await response.Content.ReadFromJsonAsync<Translate>();
                if (rv == null)
                {
                    return BadRequest("Something went Wrong ");
                }
                return rv;
            }
        }
    } } 

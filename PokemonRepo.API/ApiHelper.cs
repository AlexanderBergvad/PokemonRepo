using System;
using System.Net.Http;

namespace PokemonRepo.API
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitilizeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

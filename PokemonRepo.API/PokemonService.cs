using PokemonRepo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRepo.API
{
    public class PokemonService
    {
        public static async Task<PokemonModel> GetPokemon(string pokemonName)
        {
            string url = ApiHelper.ApiClient.BaseAddress.ToString() + pokemonName;
            

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PokemonModel Pokemon = await response.Content.ReadAsAsync<PokemonModel>();
                    return Pokemon;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

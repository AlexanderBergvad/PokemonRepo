using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PokemonRepo.Data;

namespace PoemonRepo.Pages
{
    public class FavoritesModel : PageModel
    {
        [BindProperty]
        public string FavoritePokemon { get; set; }
        public List<PokemonModel> FavoritePokemons { get; set; }

        public FavoritesModel()
        {
            FavoritePokemons = new List<PokemonModel>();
        }
        public void OnGet()
        {
            string stringPokemons = HttpContext.Session.GetString("FavoritePokemons");
            if (!string.IsNullOrEmpty(stringPokemons))
            {
                FavoritePokemons = JsonConvert.DeserializeObject<List<PokemonModel>>(stringPokemons);
            }
        }
        public IActionResult OnPost()
        {
            string stringPokemons = HttpContext.Session.GetString("FavoritePokemons");
            if (!string.IsNullOrEmpty(stringPokemons))
            {
                FavoritePokemons = JsonConvert.DeserializeObject<List<PokemonModel>>(stringPokemons);
            }

            var pokemonToRemove = FavoritePokemons.FirstOrDefault(p => p.Name == FavoritePokemon);
            if (pokemonToRemove != null)
            {
                FavoritePokemons.Remove(pokemonToRemove);
            }
            stringPokemons = JsonConvert.SerializeObject(FavoritePokemons);
            HttpContext.Session.SetString("FavoritePokemons", stringPokemons);

            return RedirectToPage("/Favorites");
        }
    }
}

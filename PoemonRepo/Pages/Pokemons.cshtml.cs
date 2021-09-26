using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PokemonRepo.Application;
using PokemonRepo.Data;

namespace PokemonRepo.UI.Pages
{
    public class PokemonsModel : PageModel
    {
        [BindProperty]
        public SearchFilters SearchBy { get; set; }
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public string FavoritePokemon { get; set; }
        public List<PokemonModel> Pokemons { get; set; }
        public List<PokemonModel> FavoritePokemons { get; set; }

        private readonly IMemoryCache _cache;
        public PokemonsModel(IMemoryCache cache)
        {
            _cache = cache;
            FavoritePokemons = new List<PokemonModel>();
        }
        public async Task OnGet()
        {
            string stringPokemons = HttpContext.Session.GetString("FavoritePokemons");

            if (!string.IsNullOrEmpty(stringPokemons))
            {
                FavoritePokemons = JsonConvert.DeserializeObject<List<PokemonModel>>(stringPokemons);
            }

            var pokemons = new List<PokemonModel>();

            if (!_cache.TryGetValue("Pokemons", out pokemons))
            {
                pokemons = await PokemonGenerator.GetAllPokemons();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set("Pokemons", pokemons, cacheEntryOptions);

                Pokemons = pokemons;
            }
            else
            {
                _cache.TryGetValue("Pokemons", out pokemons);
                Pokemons = pokemons;
            }
        }
        public async Task OnPost()
        {
            string stringPokemons = HttpContext.Session.GetString("FavoritePokemons");
            if (!string.IsNullOrEmpty(stringPokemons))
            {
                FavoritePokemons = JsonConvert.DeserializeObject<List<PokemonModel>>(stringPokemons);
            }
            var favoritePokemon = await PokemonGenerator.GetPokemon(FavoritePokemon);
            if (favoritePokemon != null)
            {
                var pokemonToRemove = FavoritePokemons.FirstOrDefault(p => p.Name == favoritePokemon.Name);
                if (pokemonToRemove != null)
                {
                    FavoritePokemons.Remove(pokemonToRemove);
                }
                else
                {
                    FavoritePokemons.Add(favoritePokemon);
                }
            }
            stringPokemons = JsonConvert.SerializeObject(FavoritePokemons);
            HttpContext.Session.SetString("FavoritePokemons", stringPokemons);

            List<PokemonModel> pokemons = new List<PokemonModel>();

            if (!_cache.TryGetValue("Pokemons", out pokemons))
            {
                pokemons = await PokemonGenerator.GetAllPokemons();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set("Pokemons", pokemons, cacheEntryOptions);

                Pokemons = pokemons;
            }
            else
            {
                _cache.TryGetValue("Pokemons", out pokemons);
                Pokemons = pokemons;
            }
            if (SearchBy == SearchFilters.Name)
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    Pokemons = pokemons.OrderBy(p => p.Name).ToList();
                }
                else
                {
                    Pokemons = Pokemons.Where(p => p.Name.StartsWith(SearchString)).OrderBy(p => p.Name).ToList();
                }
            }
            if (SearchBy == SearchFilters.Height)
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    Pokemons = pokemons.OrderBy(p => p.Height).ToList();
                }
                else
                {
                    Pokemons = Pokemons.Where(p => p.Name.StartsWith(SearchString)).OrderBy(p => p.Height).ToList();
                }
            }
            if (SearchBy == SearchFilters.Weight)
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    Pokemons = pokemons.OrderBy(p => p.Weight).ToList();
                }
                else
                {
                    Pokemons = Pokemons.Where(p => p.Name.StartsWith(SearchString)).OrderBy(p => p.Weight).ToList();
                }
            }
            if (SearchBy == SearchFilters.Move)
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    Pokemons = pokemons.OrderBy(p => p.Moves.First().move.Name).ToList();
                }
                else
                {
                    Pokemons = Pokemons.Where(p => p.Name.StartsWith(SearchString)).OrderBy(p => p.Moves.First().move.Name).ToList();
                }
            }
            if (SearchBy == SearchFilters.HeightDecending)
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    Pokemons = pokemons.OrderByDescending(p => p.Height).ToList();
                }
                else
                {
                    Pokemons = Pokemons.Where(p => p.Name.StartsWith(SearchString)).OrderByDescending(p => p.Height).ToList();
                }
            }
            if (SearchBy == SearchFilters.WeightDecending)
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    Pokemons = pokemons.OrderByDescending(p => p.Weight).ToList();
                }
                else
                {
                    Pokemons = Pokemons.Where(p => p.Name.StartsWith(SearchString)).OrderByDescending(p => p.Weight).ToList();
                }

            }
            if (SearchBy == SearchFilters.NameDecending)
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    Pokemons = pokemons.OrderByDescending(p => p.Name).ToList();
                }
                else
                {
                    Pokemons = Pokemons.Where(p => p.Name.StartsWith(SearchString)).OrderByDescending(p => p.Name).ToList();
                }
            }
        }
    }
}

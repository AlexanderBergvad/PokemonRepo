using PokemonRepo.API;
using PokemonRepo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonRepo.Application
{
    public class PokemonGenerator
    {
        public static async Task<PokemonModel> GetPokemon(string pokemonName)
        {
            try
            {
                if(pokemonName != null)
                {
                    return await PokemonService.GetPokemon(pokemonName);

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<List<PokemonModel>> GetAllPokemons()
        {
            var pokemonNames = Enum.GetValues(typeof(PokemonNames)).Cast<PokemonNames>();
            var pokemonNameslist = new List<string>();
            var pokemons = new List<PokemonModel>();
            foreach (var pokemon in pokemonNames)
            {
               pokemonNameslist.Add(pokemon.ToString().ToLower());
            }
            foreach (var pokemon in pokemonNameslist)
            {
                var pokemonToAdd = await GetPokemon(pokemon);
                if (pokemonToAdd is not null)
                {
                    pokemons.Add(pokemonToAdd);
                }
            }
            return pokemons;
   
        }
    }
}

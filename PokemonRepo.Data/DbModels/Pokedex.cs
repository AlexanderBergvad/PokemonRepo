using System;
using System.Collections.Generic;

namespace PokemonRepo.DTO
{
    public class Pokedex
    {
        public Guid Id { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}

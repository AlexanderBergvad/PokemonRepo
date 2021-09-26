using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokemonRepo.DTO;
using PokemonRepo.DTO.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRepo.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Pokedex> Pokedexes { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
    }
}

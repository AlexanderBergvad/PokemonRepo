using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PokemonRepo.DTO.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRepo.DTO

{
    public class ApplicationUser : IdentityUser
    {
        public string AboutMe { get; set; }
        public string FavoritPokemon { get; set; }
        public DateTime JoinedDate { get; set; }
        public string PhotoPath { get; set; }
        public virtual ICollection<ChatMessage> Messages { get; set; }
        public virtual ICollection<ChatRoom> ChatRooms { get; set; }
        public virtual Pokedex Pokedex { get; set; }
    }
}

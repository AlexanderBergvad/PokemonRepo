using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRepo.DTO
{
    public class Move
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
    }
}

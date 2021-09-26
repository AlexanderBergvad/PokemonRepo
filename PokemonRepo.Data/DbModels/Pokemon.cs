using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRepo.DTO
{
    public class Pokemon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Speed { get; set; }
        public int AttackPower { get; set; }
        public int Health { get; set; }
        public Move Move { get; set; }
    }
}

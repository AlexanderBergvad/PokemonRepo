using System;

namespace PokemonRepo.Data
{
    public class PokemonModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string imageString 
        {
            get
            {
                return "/PokeRepo/PokeImages/" + Name + ".png";
            }
        }
        public MovesModel[] Moves { get; set; }

    }
}

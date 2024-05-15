using FamousPokemonApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamousPokemonApiTests.Mocks
{
    public class PokemonMock
    {
        public static Pokemon Bulbasaur()
        {
            return new Pokemon
            {
                Id = 1,
                Name = "bulbasaur",
                Type = "grass/poison",
                ImageUrl = "https://pokeapi.co/media/sprites/pokemon/other/dream-world/1.svg",
                Height = 7,
                Weight = 69,
                Searchs = 1
            };
        }
    }
}

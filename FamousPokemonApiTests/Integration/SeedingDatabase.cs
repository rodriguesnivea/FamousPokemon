using FamousPokemonApi.Context;
using FamousPokemonApi.Entities;

namespace FamousPokemonIntegrationTests
{
    public class SeedingDatabase
    {
        public static void PopulateTestData(PokemonContext dbContext)
        {
            Pokemon pikachu = new Pokemon
            {
                Id = 1,
                Name = "pikachu",
                Type = "electric",
                ImageUrl = "https://example.com/pikachu.jpg",
                Height = 40,
                Weight = 6,
                Searchs = 1000
            };

            Pokemon bulbasaur = new Pokemon
            {
                Id = 2,
                Name = "bulbasaur",
                Type = "grass/poison",
                ImageUrl = "https://example.com/bulbasaur.jpg",
                Height = 70,
                Weight = 6,
                Searchs = 800
            };

            Pokemon charmander = new Pokemon
            {
                Id = 3,
                Name = "charmander",
                Type = "fire",
                ImageUrl = "https://example.com/charmander.jpg",
                Height = 60,
                Weight = 8,
                Searchs = 900
            };
            dbContext.Pokemons.Add(pikachu);
            dbContext.Pokemons.Add(bulbasaur);
            dbContext.Pokemons.Add(charmander);
            dbContext.SaveChanges();
        }
    }
}

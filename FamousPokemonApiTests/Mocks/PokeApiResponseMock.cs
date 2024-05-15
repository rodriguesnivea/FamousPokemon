using FamousPokemonApi.Clients.Models;

namespace FamousPokemonApiTests.Mocks
{
    public class PokeApiResponseMock
    {
        public static PokeApiResponse Bulbasaur()
        {
            return new PokeApiResponse
            {
                Id = 1,
                Name = "bulbasaur",
                Types = new List<TypeResponse>
                {
                    new TypeResponse { Type = new TypeName { Name = "grass" } },
                    new TypeResponse { Type = new TypeName { Name = "poison" } }
                },
                Sprites = new SpriteResponse
                {
                    Other = new Other
                    {
                        DreamWorld = new DreamWorld
                        {
                            FrontDefault = "https://pokeapi.co/media/sprites/pokemon/other/dream-world/1.svg"
                        }
                    }
                },
                Height = 7,
                Weight = 69
            };
        }
    }
}

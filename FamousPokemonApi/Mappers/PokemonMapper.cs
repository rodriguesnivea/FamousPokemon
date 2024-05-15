using FamousPokemonApi.Clients.Models;
using FamousPokemonApi.Entities;
using FamousPokemonApi.Models;

namespace FamousPokemonApi.Mappers
{
    public class PokemonMapper
    {
        public static Pokemon ToEntity(PokeApiResponse response)
        {
            var entity = new Pokemon
            {
                Id = response.Id,
                Name = response.Name,
                Type = response.Types.Select(t => t.Type.Name).Aggregate((a, b) => a + "/" + b),
                ImageUrl = response.Sprites.Other.DreamWorld.FrontDefault,
                Height = response.Height,
                Weight = response.Weight,
                Searchs = 1
            };

            return entity;
        }

        public static PokemonResponse ToResponse(Pokemon entity)
        {
            var response = new PokemonResponse
            {
                Name = entity.Name,
                Type = entity.Type,
                ImageUrl = entity.ImageUrl,
                Height = entity.Height,
                Weight = entity.Weight,
                Searchs = entity.Searchs
            };

            return response;
        }
    }
}
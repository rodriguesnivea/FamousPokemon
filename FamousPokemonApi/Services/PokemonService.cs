using FamousPokemonApi.Clients.Interfaces;
using FamousPokemonApi.Entities;
using FamousPokemonApi.Exceptions;
using FamousPokemonApi.Mappers;
using FamousPokemonApi.Models;
using FamousPokemonApi.Repositories.Interfaces;
using FamousPokemonApi.Services.Interfaces;

namespace FamousPokemonApi.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokeApiClient _client;
        private readonly IPokemonRepository _repository;
        private readonly ILogger<PokemonService> _logger;

        public PokemonService(IPokeApiClient client, IPokemonRepository repository, ILogger<PokemonService> logger)
        {
            _client = client;
            _repository = repository;
            _logger = logger;
        }

        public async Task<PokemonResponse> FindByName(string name)
        {
            _logger.LogInformation("Searching for Pokemon: {pokemonName}", name);

            var pokemonFound = await _repository.FindByName(name);

            if (pokemonFound == null)
            {
                _logger.LogInformation("Pokemon {pokemonName} not found in the repository. Fetching from API.", name);

                try
                {
                    var data = await _client.Fetch(name);
                    var pokemon = PokemonMapper.ToEntity(data);
                    pokemon = await _repository.Save(pokemon);
                    return PokemonMapper.ToResponse(pokemon);
                }
                catch (HttpRequestException ex)
                {
                    _logger.LogError(ex, "Failed to fetch Pokemon {pokemonName} from API.", name);
                    throw new NotFoundException($"Pokemon {name} does not exist");
                }
            }

            _logger.LogInformation("Pokemon {pokemonName} found in the repository.", name);

            await CountSearch(pokemonFound);
            return PokemonMapper.ToResponse(pokemonFound);
        }

        private async Task CountSearch(Pokemon pokemonFound)
        {
            pokemonFound.Searchs += 1;
            await _repository.Update(pokemonFound);
            _logger.LogInformation("Search count updated for Pokemon: {pokemonName}", pokemonFound.Name);
        }

        public async Task<List<PokemonResponse>> MostFamous(int top)
        {
            _logger.LogInformation("Fetching {top} most famous Pokemons.", top);

            var result = await _repository.MostFamous(top);
            if (result.Count() == 0)
            {
                _logger.LogWarning("No Pokemons found in the repository.");
                throw new NoContentException();
            }

            _logger.LogInformation("Fetched {count} Pokemons from the repository.", result.Count);

            return result
                .Select(PokemonMapper.ToResponse)
                .Select((pokemon, index) =>
                {
                    pokemon.Position = index + 1;
                    return pokemon;
                })
                .ToList();
        }
    }
}

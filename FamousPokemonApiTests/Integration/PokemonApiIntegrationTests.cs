using FamousPokemonApi.Models;
using System.Net.Http.Json;

namespace FamousPokemonIntegrationTests
{
    public class PokemonApiIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PokemonApiIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task DeveRetornarPokemonQuandoNomeValido()
        {
            // Arrange
            string pokemonName = "Pikachu";

            // Act
            var response = await _client.PostAsync($"/api/pokemon/{pokemonName}", null);
            response.EnsureSuccessStatusCode();
            var pokemonFromApi = await response.Content.ReadFromJsonAsync<PokemonResponse>();

            // Assert
            Assert.NotNull(pokemonFromApi);
            Assert.Equal(pokemonName.ToLower(), pokemonFromApi.Name);
            Assert.Equal("electric", pokemonFromApi.Type);
            Assert.Equal("https://example.com/pikachu.jpg", pokemonFromApi.ImageUrl);
            Assert.Equal(40, pokemonFromApi.Height);
            Assert.Equal(6, pokemonFromApi.Weight);
            Assert.Equal(1001, pokemonFromApi.Searchs);
            Assert.Equal(0, pokemonFromApi.Position);
        }

        [Fact]
        public async Task DeveRetornarErroQuandoNomeInvalido()
        {
            // Arrange
            string invalidPokemonName = "peixonalta";

            // Act
            var response = await _client.PostAsync($"/api/pokemon/{invalidPokemonName}", null);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task DeveAcessarApiPokemonESalvarPokemonQuandoNomeValido()
        {
            // Arrange
            string pokemonName = "ditto";

            // Act
            var response = await _client.PostAsync($"/api/pokemon/{pokemonName}", null);
            response.EnsureSuccessStatusCode();
            var pokemonFromApi = await response.Content.ReadFromJsonAsync<PokemonResponse>();

            // Assert
            Assert.NotNull(pokemonFromApi);
            Assert.Equal(pokemonName.ToLower(), pokemonFromApi.Name);
        }

        [Fact]
        public async Task DeveRetornarPokemonsEsperadosQuandoBuscaPokemonsMaisFamosos()
        {
            // Arrange
            int topPokemonsCount = 3;

            // Act
            var response = await _client.GetAsync($"/api/pokemon/famous?top={topPokemonsCount}");
            response.EnsureSuccessStatusCode();
            var mostFamousPokemons = await response.Content.ReadFromJsonAsync<List<PokemonResponse>>();

            // Assert
            Assert.NotNull(mostFamousPokemons);
            Assert.NotEmpty(mostFamousPokemons);
            Assert.Equal(topPokemonsCount, mostFamousPokemons.Count);
            Assert.Equal("pikachu", mostFamousPokemons[0].Name);
            Assert.Equal("charmander", mostFamousPokemons[1].Name);
            Assert.Equal("bulbasaur", mostFamousPokemons[2].Name);
        }
    }
}

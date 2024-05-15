using FamousPokemonApi.Clients.Interfaces;
using FamousPokemonApi.Clients.Models;
using System.Text.Json;

namespace FamousPokemonApi.Clients
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public PokeApiClient()
        {
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/");
        }

        public async Task<PokeApiResponse> Fetch(string name)
        {
            var response = await _httpClient.GetAsync($"/api/v2/pokemon/{name}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PokeApiResponse>(responseString);
        }
    }
}
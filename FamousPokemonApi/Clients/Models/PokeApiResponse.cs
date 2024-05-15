using System.Text.Json.Serialization;

namespace FamousPokemonApi.Clients.Models
{
    public class PokeApiResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("weight")]
        public int Weight { get; set; }
        [JsonPropertyName("types")]
        public List<TypeResponse> Types { get; set; }
        [JsonPropertyName("sprites")]
        public SpriteResponse Sprites { get; set; }

    }
}
using System.Text.Json.Serialization;

namespace FamousPokemonApi.Clients.Models
{
    public class SpriteResponse
    {
        [JsonPropertyName("other")]
        public Other Other { get; set; }
    }
}
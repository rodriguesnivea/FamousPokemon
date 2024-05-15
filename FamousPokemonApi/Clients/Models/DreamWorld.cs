using System.Text.Json.Serialization;

namespace FamousPokemonApi.Clients.Models
{
    public class DreamWorld
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }
}
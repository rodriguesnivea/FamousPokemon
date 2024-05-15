using System.Text.Json.Serialization;

namespace FamousPokemonApi.Clients.Models
{
    public class Other
    {
        [JsonPropertyName("dream_world")]
        public DreamWorld DreamWorld { get; set; }
    }
}
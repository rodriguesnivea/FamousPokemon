using System.Text.Json.Serialization;

namespace FamousPokemonApi.Clients.Models
{
    public class TypeResponse
    {
        [JsonPropertyName("type")]
        public TypeName Type { get; set; }
    }
}
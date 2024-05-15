using System.Text.Json.Serialization;

namespace FamousPokemonApi.Clients.Models
{
    public class TypeName
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
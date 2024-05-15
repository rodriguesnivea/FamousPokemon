namespace FamousPokemonApi.Models
{
    public class PokemonResponse
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Searchs { get; set; }
        public int Position { get; set; }
    }
}
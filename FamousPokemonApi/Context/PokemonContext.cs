using FamousPokemonApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamousPokemonApi.Context
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
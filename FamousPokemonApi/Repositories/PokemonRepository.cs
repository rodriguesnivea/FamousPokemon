using FamousPokemonApi.Context;
using FamousPokemonApi.Entities;
using FamousPokemonApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FamousPokemonApi.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _context;
        private readonly DbSet<Pokemon> _dbSet;

        public PokemonRepository(PokemonContext context)
        {
            _context = context;
            _dbSet = context.Pokemons;
        }

        public async Task<Pokemon> FindByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Name.Equals(name));
        }
        public async Task<List<Pokemon>> MostFamous(int top)
        {
            return await _dbSet.OrderByDescending(p => p.Searchs).Take(top).ToListAsync();
        }

        public async Task<Pokemon> Save(Pokemon entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Pokemon> Update(Pokemon entity)
        {
            var result = await _dbSet.FirstOrDefaultAsync(p => p.Id == entity.Id);
            _context.Entry(result).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
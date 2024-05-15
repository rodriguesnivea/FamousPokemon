using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamousPokemonApi.Entities;

namespace FamousPokemonApi.Repositories.Interfaces
{
    public interface IPokemonRepository
    {
        Task<Pokemon> FindByName(string name);
        Task<List<Pokemon>> MostFamous(int top);
        Task<Pokemon> Save(Pokemon entity);
        Task<Pokemon> Update(Pokemon entity);
    }
}
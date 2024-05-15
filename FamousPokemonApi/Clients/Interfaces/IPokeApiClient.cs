using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamousPokemonApi.Clients.Models;

namespace FamousPokemonApi.Clients.Interfaces
{
    public interface IPokeApiClient
    {
        Task<PokeApiResponse> Fetch(string name);
    }
}
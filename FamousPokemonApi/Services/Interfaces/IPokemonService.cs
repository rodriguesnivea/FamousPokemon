using FamousPokemonApi.Models;

namespace FamousPokemonApi.Services.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonResponse> FindByName(string name);
        Task<List<PokemonResponse>> MostFamous(int top);
    }
}
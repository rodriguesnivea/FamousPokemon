using FamousPokemonApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamousPokemonApi.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _service;

        public PokemonController(IPokemonService service)
        {
            _service = service;
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> FindPokemon([FromRoute] string name)
        {
            return Ok(await _service.FindByName(name.ToLower()));
        }

        [HttpGet("famous")]
        public async Task<IActionResult> FindMostFamous([FromQuery] int top)
        {
            return Ok(await _service.MostFamous(top));
        }
    }
}
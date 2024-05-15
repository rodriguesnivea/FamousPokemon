using FamousPokemonApi.Clients.Interfaces;
using FamousPokemonApi.Entities;
using FamousPokemonApi.Exceptions;
using FamousPokemonApi.Models;
using FamousPokemonApi.Repositories.Interfaces;
using FamousPokemonApi.Services;
using FamousPokemonApiTests.Mocks;
using Microsoft.Extensions.Logging;
using Moq;

namespace FamousPokemonApiTests.Services
{
    public class PokemonServiceTest
    {
        private PokemonService _service;
        private Mock<IPokeApiClient> _client;
        private Mock<IPokemonRepository> _repository;

        private Mock<ILogger<PokemonService>> _logger;


        public PokemonServiceTest()
        {
            _client = new Mock<IPokeApiClient>();
            _repository = new Mock<IPokemonRepository>();
            _logger = new Mock<ILogger<PokemonService>>();
            _service = new PokemonService(_client.Object, _repository.Object, _logger.Object);
        }

        [Fact]
        public async Task DeveAcessarApiPokemonESalvarPokemonQuandoNomeValido()
        {
            // Arrange
            string name = "bulbasaur";
            Pokemon expected = PokemonMock.Bulbasaur();

            _repository.Setup(r => r.FindByName(name)).ReturnsAsync((Pokemon)null);
            _repository.Setup(r => r.Save(It.IsAny<Pokemon>())).ReturnsAsync(expected);
            _client.Setup(s => s.Fetch(name)).ReturnsAsync(PokeApiResponseMock.Bulbasaur());

            // Act
            var actual = await _service.FindByName(name);

            // Assert
            AssertPokemonMatches(expected, actual);
        }

        [Fact]
        public async Task DeveLancarExcecaoNotFoundQuandoNomeInvalido()
        {
            // Arrange
            string name = "nivea";
            _repository.Setup(r => r.FindByName(name)).ReturnsAsync((Pokemon)null);
            _client.Setup(s => s.Fetch(name)).ThrowsAsync(new HttpRequestException());

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.FindByName(name));
        }

        [Fact]
        public async Task DeveRetornarPokemonDaBaseEContabilizarBuscaQuandoNomeValido()
        {
            // Arrange
            string name = "bulbasaur";
            Pokemon expected = PokemonMock.Bulbasaur();

            _repository.Setup(r => r.FindByName(name)).ReturnsAsync(expected);
            _repository.Setup(r => r.Update(expected));

            // Act
            var actual = await _service.FindByName(name);

            // Assert
            AssertPokemonMatches(expected, actual);
        }

        [Fact]
        public async Task DeveLancarExcecaoQuandoNenhumPokemonNaBase()
        {
            // Arrange
            int top = 5;

            _repository.Setup(r => r.MostFamous(top)).ReturnsAsync(new List<Pokemon>());

            // Act And Assert
            await Assert.ThrowsAsync<NoContentException>(() => _service.MostFamous(top));
        }

        private void AssertPokemonMatches(Pokemon expected, PokemonResponse actual)
        {
            Assert.NotNull(actual);
            Assert.IsType<PokemonResponse>(actual);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Weight, actual.Weight);
            Assert.Equal(expected.Height, actual.Height);
            Assert.Equal(expected.Searchs, actual.Searchs);
        }
    }
}
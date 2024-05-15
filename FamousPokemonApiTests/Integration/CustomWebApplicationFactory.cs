using FamousPokemonApi.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FamousPokemonIntegrationTests
{
    public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<PokemonContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<PokemonContext>(options =>
                {
                    options.UseInMemoryDatabase("famous_pokemon");
                });

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<PokemonContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                        // insercao informacoes no banco em memoria
                        SeedingDatabase.PopulateTestData(appContext);
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            });
        }
    }
}
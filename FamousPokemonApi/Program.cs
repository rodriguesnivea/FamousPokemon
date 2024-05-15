using FamousPokemonApi.Clients;
using FamousPokemonApi.Clients.Interfaces;
using FamousPokemonApi.Context;
using FamousPokemonApi.Middlewares;
using FamousPokemonApi.Repositories;
using FamousPokemonApi.Repositories.Interfaces;
using FamousPokemonApi.Services;
using FamousPokemonApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
string connectionString = configuration.GetSection("ConnectionStrings")["MySQLConnectionString"];

// Configura o DbContext com a string de conexão obtida do arquivo de configuração
builder.Services.AddDbContext<PokemonContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version())
    )
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FamousPokemonApi", Version = "v1" });
});

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokeApiClient, PokeApiClient>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();

public partial class Program { }
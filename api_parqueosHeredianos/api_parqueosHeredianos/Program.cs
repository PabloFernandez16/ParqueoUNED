using api_parqueosHeredianos.Models;
using api_parqueosHeredianos.Repository;
using api_parqueosHeredianos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Registrar servicios
//builder.Services.AddScoped<BaseRepository<Tiquete>, TiqueteService>();
//builder.Services.AddScoped<IServicioTiquete, TiqueteService>();
builder.Services.AddScoped<TiqueteService>();
builder.Services.AddScoped<ParqueoService>();
builder.Services.AddScoped<ReporteService>();
builder.Services.AddScoped<EmpleadoService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

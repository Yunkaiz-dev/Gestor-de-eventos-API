using Gestor_de_eventos.Abstracciones.Repositorios;
using Gestor_de_eventos.Abstracciones.Servicios;
using Gestor_de_eventos.Implementaciones.Repositorios;
using Gestor_de_eventos.Implementaciones.Servicios;
using Gestor_de_eventos.Modelos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GestorEventosContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepositorioAsistente, RepositorioAsistente>();
builder.Services.AddScoped<IServicioAsistente, ServicioAsistente>();
builder.Services.AddScoped<IServicioEvento, ServicioEvento>();
builder.Services.AddScoped<IRepositorioEvento, RepositorioEvento>();
builder.Services.AddScoped<IRepositorioTicket, RepositorioTicket>();
builder.Services.AddScoped<IServicioTicket, ServicioTicket>();

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

app.Run();

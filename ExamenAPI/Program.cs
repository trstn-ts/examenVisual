using ExamenAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//Definimos la nueva politica de los CORS para que el API sea accesible para cualquiera.
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var connectionString = builder.Configuration.GetConnectionString("cadenaSQL");
builder.Services.AddDbContext<BdRegistrosContext>(options =>
options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Activamos la nueva politica aqui
app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

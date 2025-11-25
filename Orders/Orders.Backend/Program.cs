using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//Inyeccion de dependencia del Datacontex 
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(pattern:"swagger/openapi/v1.json");
    app.UseSwaggerUI(g => g.SwaggerEndpoint("openapi/v1.json", "MyApiG V1"));
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

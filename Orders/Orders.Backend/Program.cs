var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(pattern:"swagger/openapi/v1.json");
    app.UseSwaggerUI(g => g.SwaggerEndpoint("openapi/v1.json", "MyApiG V1"));
}

/***/

//app.UseSwagger();

//app.UseSwaggerUI();

/***/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Projeto03.AcessoDados.DI;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfraStructureDb(config);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

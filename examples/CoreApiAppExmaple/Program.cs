using TBC.OpenAPI.SDK.DBI.Extensions;
using TBC.OpenAPI.SDK.DBI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<ServiceSettings>(builder.Configuration.GetSection("ServiceConfigs"))
   .AddDBIServices(builder.Configuration.GetSection("ServiceConfigs").Get<ServiceSettings>());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

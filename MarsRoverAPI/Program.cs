using MarsRoverAPI.Repositories;
using MarsRoverAPI.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var curiosityRoverBaseUrl = builder.Configuration.GetSection("ExternalServices:CuriosityRoverService:BaseUrl").Value;
var perseveranceRoverBaseUrl = builder.Configuration.GetSection("ExternalServices:PerseveranceRoverService:BaseUrl").Value;

builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICuriosityRoverRepository>(repo => new CuriosityRoverRepository(curiosityRoverBaseUrl ?? throw new Exception("Error! Curiosity Rover Base URL is not configured.")));
builder.Services.AddScoped<ICuriosityRoverService, CuriosityRoverService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


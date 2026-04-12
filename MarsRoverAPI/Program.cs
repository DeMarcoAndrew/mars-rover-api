using MarsRoverAPI.Repositories;
using MarsRoverAPI.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var marsRoverBaseUrl = builder.Configuration.GetSection("ExternalServices:CuriosityRoverService:BaseUrl").Value;

builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IMarsAPIRepository>(repo => new MarsAPIRepository(marsRoverBaseUrl ?? throw new Exception("Error! Mars Rover Base URL is not configured.")));
builder.Services.AddScoped<IMarsAPIService, MarsAPIService>();

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


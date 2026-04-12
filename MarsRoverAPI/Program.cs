using MarsRoverAPI.Repositories;
using MarsRoverAPI.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var marsRoverBaseUrl = builder.Configuration.GetSection("ExternalServices:NASAMarsAPIService:BaseUrl").Value;

builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient();
builder.Services.AddHttpClient("MarsAPI", client => client.BaseAddress = new Uri(marsRoverBaseUrl ?? throw new Exception("Error! Can't find the External Service to create the Base Address")));

builder.Services.AddScoped(typeof(IMarsAPIRepository<>), typeof(MarsAPIRepository<>));

builder.Services.AddScoped<ICuriosityRoverService, CuriosityRoverService>();
builder.Services.AddScoped<IPerseveranceRoverService, PerseveranceRoverService>();

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


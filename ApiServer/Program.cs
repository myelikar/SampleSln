using Microsoft.Extensions.DependencyInjection;
using DBLayer.Common;
using Application.Common.Support;
using Application;
string BaseDirPath = Directory.GetCurrentDirectory();
//Set Environment Variable of BASEDIR for Serilog Files
Environment.SetEnvironmentVariable("BASEDIR", BaseDirPath);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.AddSwagger();
builder.AddAuthentication();
builder.AddSerilog();
builder.Services.AddPersistance(builder.Configuration, EDbTypes.SQLITE, $"Filename={BaseDirPath}\\DemoDb.db");
builder.Services.AddApplication();
builder.Services.AddCarter();
var app = builder.Build();
app.Services.PrepDb();
app.MapCarter();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateTime.Now.AddDays(index),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

app.Run();

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
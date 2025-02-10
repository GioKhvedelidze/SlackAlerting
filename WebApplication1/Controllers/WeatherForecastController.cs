using Microsoft.AspNetCore.Mvc;
using SlackAlerting.Abstraction;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ISlackAlertService _slackAlertService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ISlackAlertService slackAlertService)
    {
        _logger = logger;
        _slackAlertService = slackAlertService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _slackAlertService.SendMessageAsync("WeatherForecast Endpoint Called 🚨");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}
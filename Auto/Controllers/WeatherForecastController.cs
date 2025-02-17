using auto.browser.Tests;
using Microsoft.AspNetCore.Mvc;

namespace Auto.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly OpenRegistration _openRegistration;
    private readonly RegisterAccount _registerAccount;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, OpenRegistration openRegistration, RegisterAccount registerAccount)
    {
        _logger = logger;
        _openRegistration = openRegistration;
        _registerAccount = registerAccount;
    }

    [HttpGet("/openRegistration")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        await _openRegistration.Run();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet("/registerAccount")]
    public async Task<IActionResult> GetRegisterAccount()
    {
        await _registerAccount.Run();
        return Ok();
    }
}

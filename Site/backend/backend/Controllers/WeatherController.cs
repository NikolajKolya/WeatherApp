using backend.Models.Api.DTOs;
using backend.Models.Api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

/// <summary>
/// Controller to get weather
/// </summary>
[ApiController]
public class WeatherController : ControllerBase
{
    /// <summary>
    /// Get current weather
    /// </summary>
    [Route("api/Weather/Current")]
    [HttpGet]
    public async Task<ActionResult<CurrentWeatherResponse>> GetCurrentWeather()
    {
        var weather = new WeatherDto(DateTime.UtcNow, 33.0);

        return Ok(new CurrentWeatherResponse(weather));
    }
}
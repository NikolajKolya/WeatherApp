using System.Security.Cryptography;
using backend.Models.Api.DTOs;
using backend.Models.Api.Responses;
using backend.Randoms;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

/// <summary>
/// Controller to get weather
/// </summary>
[ApiController]
public class WeatherController : ControllerBase
{
    /// <summary>
    /// Get current date
    /// </summary>
    [Route("api/Weather/CurrentDate")]
    [HttpGet]
    public async Task<ActionResult<CurrentDateResponse>> GetCurrentDate()
    {
        return Ok(new CurrentDateResponse(DateOnly.FromDateTime(DateTime.UtcNow)));
    }

    /// <summary>
    /// Returns full weather for given date
    /// </summary>
    [Route("api/Weather/{date}")]
    [HttpGet]
    public async Task<ActionResult<WeatherResponse>> GetCurrentWeather(DateOnly date)
    {
        RandomTemperature randomTemperature = new RandomTemperature();
        var weather = new WeatherDto
        (
            date.ToDateTime(TimeOnly.MinValue),
            randomTemperature.CreateRandomTemperature(),
            randomTemperature.CreateRandomHumidity(),
            randomTemperature.CreateRandomPressure()
        );
        
        return Ok(new WeatherResponse(date, weather));
    }

    [Route("api/Weather/GetCalendar")]
    [HttpGet]
    public async Task<ActionResult<WeatherCalendarResponse>> GetWeatherCalendar()
    {
        RandomTemperature randomTemperature = new RandomTemperature();
        
        var items = new List<WeatherCalendarItem>();
        
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        for (var i = 0; i < 7; i++)
        {
            items.Add
                (
                    new WeatherCalendarItem
                        (
                            date,
                            new ShortWeatherDto
                                (
                                    date.ToDateTime(TimeOnly.MinValue),
                                    randomTemperature.CreateRandomTemperature()
                                )
                        )
                );

            date = date.AddDays(1);
        }
        
        return Ok(new WeatherCalendarResponse(items));
    }
}
using backend.Models.Api.DTOs;
using backend.Models.Api.Responses;
using backend.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

/// <summary>
/// Controller to get weather
/// </summary>
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController
    (
        IWeatherService weatherService
    )
    {
        _weatherService = weatherService;
    }
    
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
        return Ok
        (
            new WeatherResponse
            (
                date,
                (await _weatherService.GetWeatherByDateAsync(date)).ToWeatherDto()
            )
        );
    }

    [Route("api/Weather/GetCalendar")]
    [HttpGet]
    public async Task<ActionResult<WeatherCalendarResponse>> GetWeatherCalendar()
    {
        var items = new List<WeatherCalendarItem>();
        
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        for (var i = 0; i < 7; i++)
        {
            var shortWeather = (await _weatherService.GetWeatherByDateAsync(date)).ToShortWeatherDto();
            
            items.Add
            (
                new WeatherCalendarItem
                (
                    date,
                    shortWeather
                )
            );

            date = date.AddDays(1);
        }
        
        return Ok(new WeatherCalendarResponse(items));
    }
}
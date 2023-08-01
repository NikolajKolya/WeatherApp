using System.Text.Json.Serialization;
using backend.Models.Api.DTOs;

namespace backend.Models.Api.Responses;

/// <summary>
/// Response with current weather
/// </summary>
public class CurrentWeatherResponse
{
    [JsonPropertyName("currentWeather")]
    public WeatherDto CurrentWeather { get; private set; }

    public CurrentWeatherResponse
    (
        WeatherDto currentWeather
    )
    {
        CurrentWeather = currentWeather
                         ?? throw new ArgumentNullException
                         (
                             nameof(currentWeather),
                             "Current weather must be specified!"
                         );
    }
}
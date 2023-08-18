using System.Text.Json.Serialization;
using backend.Models.Api.DTOs;

namespace backend.Models.Api.Responses;

/// <summary>
/// Response with current weather
/// </summary>
public class CurrentWeatherResponse
{
    [JsonPropertyName("currentWeather")]
    public ShortWeatherDto CurrentWeather { get; private set; }

    public CurrentWeatherResponse
    (
        ShortWeatherDto currentWeather
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
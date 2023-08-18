using System.Text.Json.Serialization;
using backend.Models.Api.DTOs;

namespace backend.Models.Api.Responses;

/// <summary>
/// Information on weather for given date
/// </summary>
public class WeatherResponse
{
    [JsonPropertyName("date")]
    public DateOnly Date { get; private set; }

    [JsonPropertyName("weather")]
    public WeatherDto Weather { get; private set; }

    public WeatherResponse
    (
        DateOnly date,
        WeatherDto weather
    )
    {
        Date = date;
        Weather = weather ?? throw new ArgumentNullException(nameof(weather), "Weather must be specified!");
    }
}
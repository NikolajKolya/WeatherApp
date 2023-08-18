using System.Text.Json.Serialization;
using backend.Models.Api.DTOs;

namespace backend.Models.Api.Responses;

public class ShortWeatherResponse
{
    [JsonPropertyName("date")]
    public DateOnly Date { get; private set; }

    [JsonPropertyName("weather")]
    public ShortWeatherDto Weather { get; private set; }

    public ShortWeatherResponse
    (
        DateOnly date,
        ShortWeatherDto weather
    )
    {
        Date = date;
        Weather = weather ?? throw new ArgumentNullException(nameof(weather), "Weather must be specified!");
    }
}
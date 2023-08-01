using System.Text.Json.Serialization;

namespace backend.Models.Api.DTOs;

/// <summary>
/// Information on weather
/// </summary>
public class WeatherDto
{
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; private set; }

    [JsonPropertyName("temperature")]
    public double Temperature { get; private set; }

    public WeatherDto
    (
        DateTime timespamp,
        double temperature
    )
    {
        // TODO: Add checks
        Timestamp = timespamp;
        Temperature = temperature;
    }
}
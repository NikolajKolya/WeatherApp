using System.Text.Json.Serialization;

namespace backend.Models.Api.DTOs;

/// <summary>
/// Short information on weather
/// </summary>
public class ShortWeatherDto
{
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; private set; }

    [JsonPropertyName("temperature")]
    public double Temperature { get; private set; }

    public ShortWeatherDto
    (
        DateTime timestamp,
        double temperature
    )
    {
        Timestamp = timestamp;
        Temperature = temperature;
    }
}
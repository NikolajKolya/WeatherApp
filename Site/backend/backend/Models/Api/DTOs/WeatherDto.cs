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

    [JsonPropertyName("humidity")]
    public double Humidity { get; private set; }

    [JsonPropertyName("pressure")]
    public double Pressure { get; private set; }

    public WeatherDto
    (
        DateTime timestamp,
        double temperature,
        double humidity,
        double pressure
    )
    {
        if (humidity < 0 & humidity > 100) throw new ArgumentOutOfRangeException(nameof(humidity));
        if (pressure <= 0) throw new ArgumentOutOfRangeException(nameof(pressure));
        Humidity = humidity;
        Pressure = pressure;
        Timestamp = timestamp;
        Temperature = temperature;
    }
}
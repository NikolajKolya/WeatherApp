using System.Text.Json.Serialization;

namespace backend.Models.Api.DTOs;

/// <summary>
/// Weather calendar item
/// </summary>
public class WeatherCalendarItem
{
    [JsonPropertyName("date")]
    public DateOnly Date { get; private set; }

    [JsonPropertyName("shortWeather")]
    public ShortWeatherDto ShortWeather { get; private set; }

    public WeatherCalendarItem
    (
        DateOnly date,
        ShortWeatherDto shortWeather
    )
    {
        Date = date;
        ShortWeather = shortWeather ??
                       throw new ArgumentNullException(nameof(shortWeather), "Short weather must be populated!");
    }
}
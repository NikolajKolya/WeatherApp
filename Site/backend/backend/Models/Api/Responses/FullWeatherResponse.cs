using System.Text.Json.Serialization;
using backend.Models.Api.DTOs;

namespace backend.Models.Api.Responses;

public class FullWeatherResponse
{
    [JsonPropertyName("weather")]
    public WeatherDto WeatherResponse { get; private set; }

    public FullWeatherResponse(WeatherDto weatherResponse)
    {
        WeatherResponse = weatherResponse
                          ?? throw new ArgumentNullException
                          (
                              nameof(weatherResponse),
                              "Weather must be specified!"
                          );
    }
}
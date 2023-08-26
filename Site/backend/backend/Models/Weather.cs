using backend.Models.Api.DTOs;

namespace backend.Models;

public class Weather
{
    public Guid Id { get; set; }
    
    public DateTime Timestamp { get; set; }
    
    public double Temperature { get; set; }
    
    public double Humidity { get; set; }
    
    public double Pressure { get; set; }

    public ShortWeatherDto ToShortWeatherDto()
    {
        return new ShortWeatherDto(Timestamp, Temperature);
    }

    public WeatherDto ToWeatherDto()
    {
        return new WeatherDto(Timestamp, Temperature, Humidity, Pressure);
    }
}
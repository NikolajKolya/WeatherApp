using backend.Models;
using backend.Services.Abstract;

namespace backend.Services.Implementations;

public class ExternalSourceWeatherService : IExternalSourceWeatherService
{
    public async Task<Weather> GetWeatherByDateAsync(DateOnly date)
    {
        return new Weather()
        {
            Timestamp = date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc),
            Temperature = 30,
            Humidity = 50,
            Pressure = 1030
        };
    }
}
using backend.Models;

namespace backend.Services.Abstract;

public interface IWeatherService
{
    /// <summary>
    /// Get last weather for given date
    /// </summary>
    Task<Weather> GetWeatherByDateAsync(DateOnly date);
}
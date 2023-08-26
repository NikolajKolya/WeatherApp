using backend.Dao.Models;

namespace backend.Dao.Abstract;

/// <summary>
/// DAO to work with weather
/// </summary>
public interface IWeatherDao
{
    /// <summary>
    /// Get last weather for given date
    /// </summary>
    Task<WeatherDbo> GetWeatherForDateAsync(DateOnly date);

    /// <summary>
    /// Save weather record to database
    /// </summary>
    Task<WeatherDbo> AddWeatherRecordAsync(WeatherDbo weather);
}
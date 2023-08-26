using backend.Models;

namespace backend.Services.Abstract;

/// <summary>
/// Сервис для получения погоды из внешнего источника
/// </summary>
public interface IExternalSourceWeatherService
{
    Task<Weather> GetWeatherByDateAsync(DateOnly date);
}
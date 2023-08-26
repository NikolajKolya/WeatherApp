using backend.Dao.Models;
using backend.Models;

namespace backend.Mappers.Abstract;

public interface IWeatherMapper
{
    IReadOnlyCollection<Weather> Map(IEnumerable<WeatherDbo> weathers);

    Weather Map(WeatherDbo weather);

    WeatherDbo Map(Weather weather);

    IReadOnlyCollection<WeatherDbo> Map(IEnumerable<Weather> weathers);
}
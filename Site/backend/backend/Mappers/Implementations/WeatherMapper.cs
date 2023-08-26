using backend.Dao.Models;
using backend.Mappers.Abstract;
using backend.Models;

namespace backend.Mappers.Implementations;

public class WeatherMapper : IWeatherMapper
{
    public IReadOnlyCollection<Weather> Map(IEnumerable<WeatherDbo> weathers)
    {
        if (weathers == null)
        {
            return null;
        }

        return weathers.Select(w => Map(w)).ToList();
    }

    public Weather Map(WeatherDbo weather)
    {
        if (weather == null)
        {
            return null;
        }

        return new Weather()
        {
            Id = weather.Id,
            Timestamp = weather.Timestamp,
            Temperature = weather.Temperature,
            Humidity = weather.Humidity,
            Pressure = weather.Pressure
        };
    }

    public WeatherDbo Map(Weather weather)
    {
        if (weather == null)
        {
            return null;
        }

        return new WeatherDbo()
        {
            Id = weather.Id,
            Timestamp = weather.Timestamp,
            Temperature = weather.Temperature,
            Humidity = weather.Humidity,
            Pressure = weather.Pressure
        };
    }

    public IReadOnlyCollection<WeatherDbo> Map(IEnumerable<Weather> weathers)
    {
        if (weathers == null)
        {
            return null;
        }

        return weathers.Select(w => Map(w)).ToList();
    }
}
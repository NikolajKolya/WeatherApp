using backend.Dao.Abstract;
using backend.Dao.Implementations;
using backend.Dao.Models;
using backend.Mappers.Abstract;
using backend.Models;
using backend.Services.Abstract;

namespace backend.Services.Implementations;

public class WeatherService : IWeatherService
{
    private readonly IWeatherDao _weatherDao;
    private readonly IWeatherMapper _weatherMapper;
    private readonly IExternalSourceWeatherService _externalSourceWeatherService;

    public WeatherService
    (
        IWeatherDao weatherDao,
        IWeatherMapper weatherMapper,
        IExternalSourceWeatherService externalSourceWeatherService
    )
    {
        _weatherDao = weatherDao;
        _weatherMapper = weatherMapper;
        _externalSourceWeatherService = externalSourceWeatherService;
    }

    public async Task<Weather> GetWeatherByDateAsync(DateOnly date)
    {
        var weatherDbo = await _weatherDao.GetWeatherForDateAsync(date);

        if (weatherDbo == null)
        {
            // Тут мы запрашиваем погоду из внешнего источника и сохраняем её в базу
            var externalWeather = await _externalSourceWeatherService.GetWeatherByDateAsync(date);

            weatherDbo = await _weatherDao.AddWeatherRecordAsync(_weatherMapper.Map(externalWeather));
        }
    
        // В этот момент мы гаранитрованно имеем погоду
        return _weatherMapper.Map(weatherDbo);
    }
}
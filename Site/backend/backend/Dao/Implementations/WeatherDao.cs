using backend.Dao.Abstract;
using backend.Dao.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Dao.Implementations;

public class WeatherDao : IWeatherDao
{
    private readonly MainDbContext _dbContext;

    public WeatherDao(MainDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<WeatherDbo> GetWeatherForDateAsync(DateOnly date)
    {
        return await _dbContext
            .WeatherRecords
            .Where(wr => DateOnly.FromDateTime(wr.Timestamp) == date)
            .OrderByDescending(wr => wr.Timestamp)
            .Take(1)
            .SingleOrDefaultAsync();
    }

    public async Task<WeatherDbo> AddWeatherRecordAsync(WeatherDbo weather)
    {
        _ = weather ?? throw new ArgumentNullException(nameof(weather), "Погода не должна быть null!");

        await _dbContext
            .WeatherRecords
            .AddAsync(weather);

        await _dbContext.SaveChangesAsync();

        return weather;
    }
}
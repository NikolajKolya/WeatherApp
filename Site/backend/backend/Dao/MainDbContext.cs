using backend.Dao.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Dao;

public class MainDbContext : DbContext
{
    /// <summary>
    /// Weather records
    /// </summary>
    public DbSet<WeatherDbo> WeatherRecords { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
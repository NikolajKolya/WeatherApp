using System.ComponentModel.DataAnnotations;

namespace backend.Dao.Models;

/// <summary>
/// Weather for given moment of time
/// </summary>
public class WeatherDbo
{
    /// <summary>
    /// Weather record ID
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    public DateTime Timestamp { get; set; }
    
    public double Temperature { get; set; }
    
    public double Humidity { get; set; }
    
    public double Pressure { get; set; }
}
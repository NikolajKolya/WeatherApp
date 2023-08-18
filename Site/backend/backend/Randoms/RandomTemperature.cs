using System;

namespace backend.Randoms;

public class RandomTemperature
{
    #region constants
    private const int MinTemperature = -10;
    private const int MaxTemperature = 50;
    
    private const int MinHumidity = 0;
    private const int MaxHumidity = 100;
    
    private const int MinPressure = 1020;
    private const int MaxPressure = 1042;

    #endregion
    
    private readonly Random _random = new Random();

    public double CreateRandomTemperature()
    {
        return _random.Next(MinTemperature * 10, MaxTemperature * 10) / 10.0; 
    }

    public double CreateRandomHumidity()
    {
        return _random.Next(MinHumidity * 10, MaxHumidity * 10) / 10.0; 
    }
    
    public double CreateRandomPressure()
    {
        return _random.Next(MinPressure * 10, MaxPressure * 10) / 10.0; 
    }
}
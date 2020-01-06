using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetCurrentWeatherAsync(Coordinates coordinates);
        Task<Forecast> GetWeatherForecastAsync(Coordinates coordinates);
    }
}

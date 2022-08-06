using System;
using WeatherKitExample.Models;

namespace WeatherKitExample.Services
{
    public interface IWeatherKitService
    {
        public string GetToken();
        Task<List<WeatherKitDataSetType>?> GetAvailability(double latitude, double longitude);
        Task<Weather?> GetWeather(double latitude, double longitude, List<WeatherKitDataSetType> datasets, string timezoneId, string language = "en");
    }
}


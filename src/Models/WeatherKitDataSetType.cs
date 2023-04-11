using System;
namespace WeatherKitExample.Models
{
    public enum WeatherKitDataSetType
    {
        None = -1,
        CurrentWeather = 0,
        ForecastDaily,
        ForecastHourly,
        ForecastNextHour,
        WeatherAlerts,
        TrendComparison
    }
}
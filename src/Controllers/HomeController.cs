using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherKitExample.Models;
using WeatherKitExample.Services;
using WeatherKitExample.ViewModels;

namespace WeatherKitExample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWeatherKitService _weatherKitService;

    public HomeController(IWeatherKitService weatherKitService, ILogger<HomeController> logger)
    {
        _weatherKitService = weatherKitService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var vm = new WeatherViewModel
        {
            Latitude = 37.3230,
            Longitude = -122.0322
        };

        await GetWeatherForecast(vm);

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Index(WeatherViewModel vm)
    {
        await GetWeatherForecast(vm);

        return View(vm);
    }

    private async Task GetWeatherForecast(WeatherViewModel vm)
    {
        var availability = await _weatherKitService.GetAvailability(vm.Latitude, vm.Longitude);
        if (availability?.Contains(WeatherKitDataSetType.ForecastDaily) == true)
        {
            vm.Weather = await _weatherKitService.GetWeather(
                51.9333, 177.45,
                new List<WeatherKitDataSetType>() { WeatherKitDataSetType.ForecastDaily },
                TimeZoneInfo.Local.Id);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


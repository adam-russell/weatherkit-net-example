using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WeatherKitExample.Models;
using System.Security.Cryptography;
using WeatherKitExample.Helpers;
using WeatherKitExample.Services;

namespace WeatherKitExample.Controllers.API
{
    public class WeatherKitAPIController : Controller
    {
        private readonly IWeatherKitService _weatherKitService;

        public WeatherKitAPIController(IWeatherKitService weatherKitService)
        {
            _weatherKitService = weatherKitService;
        }

        [Route("api/weatherkit/gettoken")]
        public string GetWeatherKitToken()
        {
            return _weatherKitService.GetToken();
        }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using WeatherKitExample.Models;

namespace WeatherKitExample.ViewModels
{
    public class WeatherViewModel
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public Weather? Weather { get; set; }
    }
}


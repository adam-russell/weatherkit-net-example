using System;
namespace WeatherKitExample.Models
{
    public class WeatherKitSettings
    {
        public string? BaseUrl { get; set; }
        public string? ServiceID { get; set; }
        public string? PrivateKey { get; set; }
        public string? KeyIdentifier { get; set; }
        public string? TeamID { get; set; }
        public int? TokenExpirationMinutes { get; set; }
    }
}


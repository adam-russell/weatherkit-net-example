
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WeatherKitExample.Models
{
    public partial class Weather
    {
        [JsonPropertyName("currentWeather")]
        public CurrentWeather? CurrentWeather { get; set; }

        [JsonPropertyName("forecastDaily")]
        public ForecastDaily? ForecastDaily { get; set; }

        [JsonPropertyName("forecastHourly")]
        public ForecastHourly? ForecastHourly { get; set; }
    }

    public partial class CurrentWeather
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonPropertyName("asOf")]
        public DateTimeOffset? AsOf { get; set; }

        [JsonPropertyName("cloudCover")]
        public double? CloudCover { get; set; }

        [JsonPropertyName("conditionCode")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ConditionCode? ConditionCode { get; set; }

        [JsonPropertyName("daylight")]
        public bool? Daylight { get; set; }

        [JsonPropertyName("humidity")]
        public double? Humidity { get; set; }

        [JsonPropertyName("precipitationIntensity")]
        public double? PrecipitationIntensity { get; set; }

        [JsonPropertyName("pressure")]
        public double? Pressure { get; set; }

        [JsonPropertyName("pressureTrend")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PressureTrend? PressureTrend { get; set; }

        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        [JsonPropertyName("temperatureApparent")]
        public double? TemperatureApparent { get; set; }

        [JsonPropertyName("temperatureDewPoint")]
        public double? TemperatureDewPoint { get; set; }

        [JsonPropertyName("uvIndex")]
        public long? UvIndex { get; set; }

        [JsonPropertyName("visibility")]
        public double? Visibility { get; set; }

        [JsonPropertyName("windDirection")]
        public long? WindDirection { get; set; }

        [JsonPropertyName("windGust")]
        public double? WindGust { get; set; }

        [JsonPropertyName("windSpeed")]
        public double? WindSpeed { get; set; }

        [JsonPropertyName("forecastStart")]
        public DateTimeOffset? ForecastStart { get; set; }

        [JsonPropertyName("precipitationAmount")]
        public double? PrecipitationAmount { get; set; }

        [JsonPropertyName("precipitationChance")]
        public double? PrecipitationChance { get; set; }

        [JsonPropertyName("precipitationType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PrecipitationType? PrecipitationType { get; set; }

        [JsonPropertyName("snowfallIntensity")]
        public double? SnowfallIntensity { get; set; }
    }

    public partial class Metadata
    {
        [JsonPropertyName("attributionURL")]
        public Uri? AttributionUrl { get; set; }

        [JsonPropertyName("expireTime")]
        public DateTimeOffset? ExpireTime { get; set; }

        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("readTime")]
        public DateTimeOffset? ReadTime { get; set; }

        [JsonPropertyName("reportedTime")]
        public DateTimeOffset? ReportedTime { get; set; }

        [JsonPropertyName("units")]
        public string? Units { get; set; }

        [JsonPropertyName("version")]
        public long? Version { get; set; }
    }

    public partial class ForecastDaily
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonPropertyName("days")]
        public List<Day>? Days { get; set; }
    }

    public partial class Day
    {
        [JsonPropertyName("forecastStart")]
        public DateTimeOffset? ForecastStart { get; set; }

        [JsonPropertyName("forecastEnd")]
        public DateTimeOffset? ForecastEnd { get; set; }

        [JsonPropertyName("conditionCode")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ConditionCode? ConditionCode { get; set; }

        [JsonPropertyName("maxUvIndex")]
        public long? MaxUvIndex { get; set; }

        [JsonPropertyName("moonPhase")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MoonPhase? MoonPhase { get; set; }

        [JsonPropertyName("moonrise")]
        public DateTimeOffset? Moonrise { get; set; }

        [JsonPropertyName("moonset")]
        public DateTimeOffset? Moonset { get; set; }

        [JsonPropertyName("precipitationAmount")]
        public double? PrecipitationAmount { get; set; }

        [JsonPropertyName("precipitationChance")]
        public double? PrecipitationChance { get; set; }

        [JsonPropertyName("precipitationType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PrecipitationType? PrecipitationType { get; set; }

        [JsonPropertyName("snowfallAmount")]
        public double? SnowfallAmount { get; set; }

        [JsonPropertyName("solarMidnight")]
        public DateTimeOffset? SolarMidnight { get; set; }

        [JsonPropertyName("solarNoon")]
        public DateTimeOffset? SolarNoon { get; set; }

        [JsonPropertyName("sunrise")]
        public DateTimeOffset? Sunrise { get; set; }

        [JsonPropertyName("sunriseCivil")]
        public DateTimeOffset? SunriseCivil { get; set; }

        [JsonPropertyName("sunriseNautical")]
        public DateTimeOffset? SunriseNautical { get; set; }

        [JsonPropertyName("sunriseAstronomical")]
        public DateTimeOffset? SunriseAstronomical { get; set; }

        [JsonPropertyName("sunset")]
        public DateTimeOffset? Sunset { get; set; }

        [JsonPropertyName("sunsetCivil")]
        public DateTimeOffset? SunsetCivil { get; set; }

        [JsonPropertyName("sunsetNautical")]
        public DateTimeOffset? SunsetNautical { get; set; }

        [JsonPropertyName("sunsetAstronomical")]
        public DateTimeOffset? SunsetAstronomical { get; set; }

        [JsonPropertyName("temperatureMax")]
        public double? TemperatureMax { get; set; }

        [JsonPropertyName("temperatureMin")]
        public double? TemperatureMin { get; set; }

        [JsonPropertyName("daytimeForecast")]
        public Forecast? DaytimeForecast { get; set; }

        [JsonPropertyName("overnightForecast")]
        public Forecast? OvernightForecast { get; set; }

        [JsonPropertyName("restOfDayForecast")]
        public Forecast? RestOfDayForecast { get; set; }
    }

    public partial class Forecast
    {
        [JsonPropertyName("forecastStart")]
        public DateTimeOffset? ForecastStart { get; set; }

        [JsonPropertyName("forecastEnd")]
        public DateTimeOffset? ForecastEnd { get; set; }

        [JsonPropertyName("cloudCover")]
        public double? CloudCover { get; set; }

        [JsonPropertyName("conditionCode")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ConditionCode? ConditionCode { get; set; }

        [JsonPropertyName("humidity")]
        public double? Humidity { get; set; }

        [JsonPropertyName("precipitationAmount")]
        public double? PrecipitationAmount { get; set; }

        [JsonPropertyName("precipitationChance")]
        public double? PrecipitationChance { get; set; }

        [JsonPropertyName("precipitationType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PrecipitationType? PrecipitationType { get; set; }

        [JsonPropertyName("snowfallAmount")]
        public double? SnowfallAmount { get; set; }

        [JsonPropertyName("windDirection")]
        public long? WindDirection { get; set; }

        [JsonPropertyName("windSpeed")]
        public double? WindSpeed { get; set; }
    }

    public partial class ForecastHourly
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonPropertyName("hours")]
        public List<CurrentWeather>? Hours { get; set; }
    }

    public enum ConditionCode
    {
        [Display(Name = "Clear")]
        Clear,
        [Display(Name = "Cloudy")]
        Cloudy,
        [Display(Name = "Haze")]
        Haze,
        [Display(Name = "Mostly Clear")]
        MostlyClear,
        [Display(Name = "Mostly Cloudy")]
        MostlyCloudy,
        [Display(Name = "Partly Cloudy")]
        PartlyCloudy,
        [Display(Name = "Scattered Thunderstorms")]
        ScatteredThunderstorms,
        [Display(Name = "Breezy")]
        Breezy,
        [Display(Name = "Windy")]
        Windy,
        [Display(Name = "Drizzle")]
        Drizzle,
        [Display(Name = "Heavy Rain")]
        HeavyRain,
        [Display(Name = "Rain")]
        Rain,
        [Display(Name = "Flurries")]
        Flurries,
        [Display(Name = "Heavy Snow")]
        HeavySnow,
        [Display(Name = "Sleet")]
        Sleet,
        [Display(Name = "Snow")]
        Snow,
        [Display(Name = "Blizzard")]
        Blizzard,
        [Display(Name = "Blowing Snow")]
        BlowingSnow,
        [Display(Name = "Freezing Drizzle")]
        FreezingDrizzle,
        [Display(Name = "Freezing Rain")]
        FreezingRain,
        [Display(Name = "Frigid")]
        Frigid,
        [Display(Name = "Hail")]
        Hail,
        [Display(Name = "Hot")]
        Hot,
        [Display(Name = "Hurricane")]
        Hurricane,
        [Display(Name = "Isolated Thunderstorms")]
        IsolatedThunderstorms,
        [Display(Name = "Tropical Storm")]
        TropicalStorm,
        [Display(Name = "Blowing Dust")]
        BlowingDust,
        [Display(Name = "Foggy")]
        Foggy,
        [Display(Name = "Smoky")]
        Smoky,
        [Display(Name = "Strong Storms")]
        StrongStorms,
        [Display(Name = "Sun Flurries")]
        SunFlurries,
        [Display(Name = "Sun Showers")]
        SunShowers,
        [Display(Name = "Thunderstorms")]
        Thunderstorms,
        [Display(Name = "Wintry Mix")]
        WintryMix
    }

    public enum PrecipitationType
    {
        Clear,
        Precipitation,
        Rain,
        Snow,
        Sleet,
        Hail,
        Mixed
    }

    public enum PressureTrend
    {
        Falling,
        Rising,
        Steady
    }

    public enum MoonPhase
    {
        New,
        WaxingCrescent,
        FirstQuarter,
        Full,
        WaxingGibbous,
        WaningGibbous,
        ThirdQuarter,
        WaningCrescent
    }
}
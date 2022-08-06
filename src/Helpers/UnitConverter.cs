using System;
namespace WeatherKitExample.Helpers
{
    public static class UnitConverter
    {
        public static double? ConvertCelsiusToFahrenheight(double? temperature)
        {
            if (temperature == null)
                return null;

            return temperature * 9 / 5 + 32;
        }
    }
}

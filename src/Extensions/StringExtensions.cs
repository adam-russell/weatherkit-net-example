using System;
namespace WeatherKitExample.Extensions
{
    public static class StringExtensions
    {
        // From https://stackoverflow.com/questions/21755757/first-character-of-string-lowercase-c-sharp
        // Answer by Amit Joki, edited by Tono Nam
        public static string? FirstCharToLowerCase(this string? str)
        {
            if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
                return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str[1..];

            return str;
        }
    }
}


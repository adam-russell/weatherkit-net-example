using System;
namespace WeatherKitExample.Helpers
{
    public static class EncodingHelper
    {
        // Base64 Encode Per the JWT specifications
        public static string JwtBase64Encode(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (bytes.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(bytes));

            return Convert.ToBase64String(bytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .TrimEnd('=');
        }
    }
}


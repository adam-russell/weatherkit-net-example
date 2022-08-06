using System;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WeatherKitExample.Models;
using System.Security.Cryptography;
using WeatherKitExample.Helpers;
using System.Net;
using System.Net.Http.Headers;
using WeatherKitExample.Extensions;
using TimeZoneConverter;
using System.Web;

namespace WeatherKitExample.Services
{
    public class WeatherKitService : IWeatherKitService
    {
        protected static CancellationTokenSource _cts = new CancellationTokenSource();

        private WeatherKitSettings _weatherKitSettings;

        public WeatherKitService(IOptions<WeatherKitSettings> weatherKitSettings)
        {
            if (weatherKitSettings == null)
                throw new ArgumentNullException(nameof(weatherKitSettings));

            _weatherKitSettings = weatherKitSettings.Value;
        }

        public string GetToken()
        {
            var header = new
            {
                // The encryption algorithm (alg) used to encrypt the token. ES256 should be used to
                // encrypt your token, and the value for this field should be "ES256".
                alg = "ES256",

                // A 10-character key identifier (kid) key, obtained from your Apple Developer account.
                kid = _weatherKitSettings.KeyIdentifier,

                // An identifier that consists of your 10-character Team ID and Service ID, separated by a period.
                id = _weatherKitSettings.TeamID + "." + _weatherKitSettings.ServiceID
            };

            var payload = new
            {
                // The Issuer (iss) registered claim key. This key's value is your 10-character Team ID,
                // obtained from your developer account.
                iss = _weatherKitSettings.TeamID,

                // The Issued At (iat) registered claim key. The value of this key indicates the time at
                // which the token was generated, in terms of the number of seconds since UNIX Epoch, in UTC.
                iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),

                // The Expiration Time (exp) registered claim key, in terms of the number of seconds since
                // UNIX Epoch, in UTC.
                exp = DateTimeOffset.UtcNow.AddMinutes(_weatherKitSettings.TokenExpirationMinutes ?? 30).ToUnixTimeSeconds(),

                // The subject public claim key. This value is your registered Service ID.
                sub = _weatherKitSettings.ServiceID
            };

            var headerBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(header));
            var payloadBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload));

            var message = EncodingHelper.JwtBase64Encode(headerBytes)
                + "." + EncodingHelper.JwtBase64Encode(payloadBytes);

            var messageBytes = Encoding.UTF8.GetBytes(message);

            var crypto = ECDsa.Create();
            crypto.ImportPkcs8PrivateKey(Convert.FromBase64String(_weatherKitSettings.PrivateKey ?? string.Empty), out _);

            var signature = crypto.SignData(messageBytes, HashAlgorithmName.SHA256);

            return message + "." + EncodingHelper.JwtBase64Encode(signature);
        }

        public async Task<List<WeatherKitDataSetType>?> GetAvailability(double latitude, double longitude)
        {
            if (string.IsNullOrEmpty(_weatherKitSettings.BaseUrl))
                throw new Exception("Missing WeatherKit BaseUrl");

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", AppSettings.ServiceUserAgent);
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GetToken());

                var requestUri = new Uri(_weatherKitSettings.BaseUrl).Append(string.Format("availability/{0}/{1}", latitude, longitude));

                using (var response = await client.GetAsync(requestUri, _cts.Token))
                {
                    response.EnsureSuccessStatusCode();

                    using (var httpStream = await response.Content.ReadAsStreamAsync())
                    {
                        return (await JsonSerializer.DeserializeAsync<List<string>>(httpStream))?
                            .Select(d => (WeatherKitDataSetType)Enum.Parse(typeof(WeatherKitDataSetType), d, true))
                            .ToList();
                    }
                }
            }
        }

        public async Task<Weather?> GetWeather(double latitude, double longitude, List<WeatherKitDataSetType> datasets, string timezoneId, string language = "en")
        {
            if (string.IsNullOrEmpty(_weatherKitSettings.BaseUrl))
                throw new Exception("Missing WeatherKit BaseUrl");

            if (datasets.Count < 1)
                throw new ArgumentOutOfRangeException(nameof(datasets));

            var timezoneInfo = TZConvert.GetTimeZoneInfo(timezoneId);

            var ianaTimezone = (timezoneInfo.HasIanaId) ? timezoneInfo.Id : TZConvert.WindowsToIana(timezoneInfo.Id);

            if (timezoneInfo == null)
                throw new ArgumentOutOfRangeException(nameof(datasets));

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", AppSettings.ServiceUserAgent);
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GetToken());

                var datasetsString = string.Join(",", datasets.Select(d => d.ToString().FirstCharToLowerCase()));

                var requestUri = new Uri(_weatherKitSettings.BaseUrl)
                    .Append(string.Format("weather/{0}/{1}/{2}?dataSets={3}&timezone={4}",
                        language,
                        latitude,
                        longitude,
                        Uri.EscapeDataString(datasetsString),
                        Uri.EscapeDataString(ianaTimezone)));

                using (var response = await client.GetAsync(requestUri, _cts.Token))
                {
                    response.EnsureSuccessStatusCode();

                    var blah = await response.Content.ReadAsStringAsync();

                    using (var httpStream = await response.Content.ReadAsStreamAsync())
                    {
                        return await JsonSerializer.DeserializeAsync<Weather>(httpStream);
                    }
                }
            }
        }
    }
}


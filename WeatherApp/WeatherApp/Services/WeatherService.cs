using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        private const string API_BASE_URI = "https://api.openweathermap.org/data/2.5";
        private const string CURRENT_WEATHER_ENDPOINT = API_BASE_URI + "/weather?lat={0}&lon={1}&units=metric&APPID={2}";
        private const string FORECAST_ENDPOINT = API_BASE_URI + "/forecast?lat={0}&lon={1}&units=metric&APPID={2}";

        public WeatherService(HttpClient httpClient, string apiKey)
        {
            _client = httpClient;
            _apiKey = apiKey;
        }

        private async Task<T> FetchApi<T>(string endpoint)
        {
            HttpResponseMessage response = await _client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                T data = JsonConvert.DeserializeObject<T>(content);
                return data;
            }
            throw new HttpRequestException($"Status: {response.StatusCode}\nMessage: {response.ReasonPhrase}");
        }

        public async Task<WeatherData> GetCurrentWeatherAsync(Coordinates coordinates)
        {
            string endpoint = string.Format(CURRENT_WEATHER_ENDPOINT, coordinates.Lat, coordinates.Lon, _apiKey);
            return await FetchApi<WeatherData>(endpoint);
        }

        public async Task<Forecast> GetWeatherForecastAsync(Coordinates coordinates)
        {
            string endpoint = string.Format(FORECAST_ENDPOINT, coordinates.Lat, coordinates.Lon, _apiKey);
            return await FetchApi<Forecast>(endpoint);
        }
    }
}

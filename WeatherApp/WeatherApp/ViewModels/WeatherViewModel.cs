using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        private readonly IWeatherService _weatherService;
        private WeatherData _currentWeather;
        private WeatherData _forecastDayOne;
        private WeatherData _forecastDayTwo;
        private WeatherData _forecastDayThree;
        private WeatherData _forecastDayFour;
        private City _city;
        private bool _isFetchingWeather;
        private bool _isFetchingForecast;

        public WeatherViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
            Forecast = new ObservableCollection<WeatherData>();
            Task.Run(() => GetWeatherAsync());
            Task.Run(() => GetForecastAsync());
        }

        public WeatherData CurrentWeather
        {
            get => _currentWeather;
            set => SetProperty(ref _currentWeather, value);
        }
        public City City
        {
            get => _city;
            private set => SetProperty(ref _city, value);
        }
        public ObservableCollection<WeatherData> Forecast { get; }
        public WeatherData ForecastDayOne
        {
            get => _forecastDayOne;
            set => SetProperty(ref _forecastDayOne, value);
        }
        public WeatherData ForecastDayTwo
        {
            get => _forecastDayTwo;
            set => SetProperty(ref _forecastDayTwo, value);
        }
        public WeatherData ForecastDayThree
        {
            get => _forecastDayThree;
            set => SetProperty(ref _forecastDayThree, value);
        }
        public WeatherData ForecastDayFour
        {
            get => _forecastDayFour;
            set => SetProperty(ref _forecastDayFour, value);
        }
        public bool IsFetchingWeather
        {
            get => _isFetchingWeather;
            set => SetProperty(ref _isFetchingWeather, value);
        }
        public bool IsFetchingForecast
        {
            get => _isFetchingForecast;
            set => SetProperty(ref _isFetchingForecast, value);
        }

        protected virtual async Task<Coordinates> GetCoordinatesAsync()
        {
            try
            {
                Location location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null) return null;
                return new Coordinates
                {
                    Lat = location.Latitude,
                    Lon = location.Longitude
                };
            }
            catch (FeatureNotSupportedException)
            {
                string title = "Geolocation not supported";
                string message = "";
                string cancel = "OK";
                await Application.Current?.MainPage?.DisplayAlert(title, message, cancel);
                return null;
            }
            catch (FeatureNotEnabledException)
            {
                string title = "Geolocation not enabled";
                string message = "Enable geolocation to app runs correctly";
                string cancel = "OK";
                await Application.Current?.MainPage?.DisplayAlert(title, message, cancel);
                return null;
            }
            catch (PermissionException)
            {
                string title = "Can't access device geolocation";
                string message = "Allow the app to access the device geolocation to app runs corretly";
                string accept = "Settings";
                string cancel = "Close";
                bool result = await Application.Current?.MainPage?.DisplayAlert(title, message, accept, cancel);
                if(result)
                {
                    AppInfo.ShowSettingsUI();
                }
                return null;
            }
            catch (Exception)
            {
                string title = "Can't get device geolocation";
                string message = "";
                string cancel = "OK";
                await Application.Current?.MainPage?.DisplayAlert(title, message, cancel);
                return null;
            }

        }

        public async Task GetWeatherAsync()
        {
            IsFetchingWeather = true;
            Coordinates coordinates = await GetCoordinatesAsync();
            if (coordinates is null)
            {
                IsFetchingWeather = false;
                return;
            }
            CurrentWeather = await _weatherService.GetCurrentWeatherAsync(coordinates);
            IsFetchingWeather = false;
        }

        public async Task GetForecastAsync()
        {
            IsFetchingForecast = true;
            Coordinates coordinates = await GetCoordinatesAsync();
            if (coordinates is null)
            {
                IsFetchingForecast = false;
                return;
            }
            Forecast forecast = await _weatherService.GetWeatherForecastAsync(coordinates);
            City = forecast.City;
            Forecast.Clear();
            foreach (WeatherData weather in forecast.List)
            {
                var date = DateTime.Parse(weather.DateText);
                if (date.Hour == 0)
                {
                    Forecast.Add(weather);
                }
            }
            ForecastDayOne = Forecast[0];
            ForecastDayTwo = Forecast[1];
            ForecastDayThree = Forecast[2];
            ForecastDayFour = Forecast[3];
            IsFetchingForecast = false;
        }

    }
}

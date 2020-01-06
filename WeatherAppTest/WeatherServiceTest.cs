using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.Protected;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherAppTest.Helpers;
using Xunit;

namespace WeatherAppTest
{
    public class WeatherServiceTest
    {
        [Fact]
        public async void FetchCurrentWeatherFromCoordinates()
        {
            HttpMessageHandler handlerMock = MockHttpMessageHandler.CreateMock(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(
                        FromEmbedResources.ReadText("ResponseMock.CurrentWeatherResponse.json"))
                });
            var httpClient = new HttpClient(handlerMock);
            var coordinates = new Coordinates
            {
                Lat = 51.51f, 
                Lon = -0.13f
            };
            IWeatherService weatherService = new WeatherService(httpClient, "");

            WeatherData result = await weatherService.GetCurrentWeatherAsync(coordinates);

            result.Should().NotBeNull();
        }

        [Fact]
        public async void FetchForecastFromCoordinates_ReturnFiveDaysForecast()
        {
            HttpMessageHandler handlerMock = MockHttpMessageHandler.CreateMock(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(
                        FromEmbedResources.ReadText("ResponseMock.ForecastResponse.json"))
                });
            var httpClient = new HttpClient(handlerMock);
            var coordinates = new Coordinates
            {
                Lat = 51.51f,
                Lon = -0.13f
            };
            IWeatherService weatherService = new WeatherService(httpClient, "");

            Forecast result = await weatherService.GetWeatherForecastAsync(coordinates);

            result.Should().NotBeNull();
            result.List.Should().NotBeEmpty();
        }
    }
}

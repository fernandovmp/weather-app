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
using WeatherApp.ViewModels;
using WeatherAppTest.Helpers;
using Xunit;

namespace WeatherAppTest
{
    public class WeatherViewModelTest
    {
        [Fact]
        public async Task CurrentWeatherShouldNotBeNull()
        {
            HttpMessageHandler handlerMock = MockHttpMessageHandler.CreateMock(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(
                        FromEmbedResources.ReadText("ResponseMock.CurrentWeatherResponse.json"))
                });
            var httpClient = new HttpClient(handlerMock);
            IWeatherService weatherService = new WeatherService(httpClient, "");
            WeatherViewModel weatherViewModelMock = MockWeatherViewModel.CreateMock(weatherService);

            await weatherViewModelMock.GetWeatherAsync();

            weatherViewModelMock.CurrentWeather.Should().NotBeNull();
        }
        [Fact]
        public async Task ForecastCountShouldBeFour()
        {
            HttpMessageHandler handlerMock = MockHttpMessageHandler.CreateMock(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(
                        FromEmbedResources.ReadText("ResponseMock.ForecastResponse.json"))
                });
            var httpClient = new HttpClient(handlerMock);
            IWeatherService weatherService = new WeatherService(httpClient, "");
            WeatherViewModel weatherViewModelMock = MockWeatherViewModel.CreateMock(weatherService);

            await weatherViewModelMock.GetForecastAsync();

            weatherViewModelMock.Forecast.Should().HaveCount(4);
        }
    }
}

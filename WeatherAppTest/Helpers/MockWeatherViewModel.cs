using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherAppTest.Helpers
{
    internal static class MockWeatherViewModel
    {
        internal static Mock<WeatherViewModel> CreateMock(IWeatherService weatherService)
        {
            var weatherViewModelMock = new Mock<WeatherViewModel>(MockBehavior.Strict, weatherService);
            weatherViewModelMock.Protected()
                .Setup<Task<Coordinates>>("GetCoordinatesAsync")
                .ReturnsAsync(new Coordinates
                {
                    Lat = 51.51f,
                    Lon = -0.13f
                }).Verifiable();
            return weatherViewModelMock;
        }
    }
}

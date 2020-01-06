using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class Forecast
    {
        public City City { get; set; }
        public WeatherData[] List { get; set; }
    }
}

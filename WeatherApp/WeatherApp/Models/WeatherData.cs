using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public WeatherMainInfo Main { get; set; }
        public Weather[] Weather { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public WeatherSys Sys { get; set; }
        public int Dt { get; set; }
    }
}

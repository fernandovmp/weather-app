using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class WeatherMainInfo
    {
        public float Temp { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
        public float FeelsLike { get; set; }
        public float Pressure { get; set; }
        public int Humidity { get; set; }
        public float SeaLevel { get; set; }
        public float GrndLevel { get; set; }
    }
}

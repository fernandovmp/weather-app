using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class WeatherMainInfo
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }
        [JsonProperty("temp_min")]
        public float MinimumTemperature { get; set; }
        [JsonProperty("temp_max")]
        public float MaximumTemperature { get; set; }
        [JsonProperty("feels_like")]
        public float FeelsLike { get; set; }
        public float Pressure { get; set; }
        public int Humidity { get; set; }
        [JsonProperty("sea_level")]
        public float SeaLevel { get; set; }
        [JsonProperty("grnd_level")]
        public float GroundLevel { get; set; }
    }
}

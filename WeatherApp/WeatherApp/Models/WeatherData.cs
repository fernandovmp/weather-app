using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public WeatherMainInfo Main { get; set; }
        public Weather[] Weather { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public WeatherSys Sys { get; set; }
        [JsonProperty("dt")]
        public int Date { get; set; }
        [JsonProperty("dt_txt")]
        public string DateText { get; set; }
    }
}

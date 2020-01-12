using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForecastView : ContentView
    {
        public ForecastView()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static BindableProperty WeatherProperty = BindableProperty.Create(nameof(Weather),
            typeof(WeatherData), typeof(ForecastView));
        public WeatherData Weather
        {
            get => (WeatherData) GetValue(WeatherProperty);
            set => SetValue(WeatherProperty, value);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            WeatherViewModel weatherViewModel = (Application.Current as App).Container
                .Resolve(typeof(WeatherViewModel), DryIoc.IfUnresolved.ReturnDefault) as WeatherViewModel;
            BindingContext = weatherViewModel;
            weatherViewModel.FetchWeatherAndForecastCommand.Execute(null);
        }
    }
}
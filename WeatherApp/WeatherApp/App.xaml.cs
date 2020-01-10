using System;
using System.Net.Http;
using DryIoc;
using WeatherApp.Helpers;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetupDependencyContainer();
            MainPage = new MainPage();
        }

        public IContainer Container { get; private set; }

        private void SetupDependencyContainer()
        {
            Container = new Container();
            Container.RegisterInstance(new HttpClient());
            Container.Register<IWeatherService, WeatherService>(Reuse.Singleton, 
                Parameters.Of.Type<string>(defaultValue: Secrets.ApiKey));
            Container.Register<WeatherViewModel>(Reuse.Transient);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

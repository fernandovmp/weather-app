using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherAnimationView : ContentView
    {
        private static readonly Dictionary<string, string> s_sharedAnimationsToDayAndNight = 
            new Dictionary<string, string>()
            {
                {"03n", "03d"},
                {"04n", "04d"},
                {"11n", "11d"},
                {"13n", "13d"},
                {"50n", "50d"}
            };

        public WeatherAnimationView()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation), 
            typeof(string), typeof(WeatherAnimationView), defaultValue: "01d");
        public static BindableProperty OnlyDayAnimationProperty = BindableProperty.Create(nameof(OnlyDayAnimation),
            typeof(bool), typeof(WeatherAnimationView), defaultValue: false);

        public string Animation
        {
            get
            {
                var value = (string)GetValue(AnimationProperty);
                if(s_sharedAnimationsToDayAndNight.ContainsKey(value))
                {
                    return s_sharedAnimationsToDayAndNight[value];
                }
                if(OnlyDayAnimation)
                {
                    return value.Replace("n", "d");
                }
                return value;
            }
            set => SetValue(AnimationProperty, value);
        }
        public bool OnlyDayAnimation
        {
            get => (bool) GetValue(OnlyDayAnimationProperty);
            set => SetValue(OnlyDayAnimationProperty, value);
        }
    }
}
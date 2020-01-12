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
    public partial class MeasurementView : ContentView
    {
        public MeasurementView()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string),
            typeof(MeasurementView));
        public static BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(string),
            typeof(MeasurementView));
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string),
            typeof(MeasurementView));

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }
}
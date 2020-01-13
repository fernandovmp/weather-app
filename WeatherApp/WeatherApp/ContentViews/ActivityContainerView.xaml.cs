using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.ContentViews
{
    [ContentProperty(nameof(ContentElement))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityContainerView : ContentView
    {
        public ActivityContainerView()
        {
            InitializeComponent();
        }

        public static BindableProperty IsLoadingProperty = BindableProperty.Create(nameof(IsLoading),
            typeof(bool), typeof(ActivityContainerView), propertyChanged: IsLoadingChanged);
        public static BindableProperty ContentElementProperty = BindableProperty.Create(nameof(ContentElement),
            typeof(View), typeof(ActivityContainerView), propertyChanged: OnContentElementChanged);

        public bool IsLoading
        {
            get => (bool) GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }
        public View ContentElement
        {
            get => (View)GetValue(ContentElementProperty);
            set => SetValue(ContentElementProperty, value);
        }
        private static void IsLoadingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var activityContainer = bindable as ActivityContainerView;
            bool isLoading = (bool) newValue;
            ActivityIndicator indicator = activityContainer.activityIndicator;
            indicator.IsVisible = isLoading;
            indicator.IsRunning = isLoading;
            activityContainer.contentView.IsVisible = !isLoading;
        }
        private static void OnContentElementChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var activityContainer = bindable as ActivityContainerView;
            View content = newValue as View;
            activityContainer.contentView.Content = content;
        }
    }
}
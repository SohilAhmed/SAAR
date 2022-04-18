using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAAR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Title = $"SAAR";
        }

        private async void OutstandingsFrameClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(OutstandingsPage)}");
        }

        private async void LogoutCicked(object sender, EventArgs e)
        {
            Preferences.Set(CommonClass.SharedKeyMobile, "");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async void DispatchInfoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(DispatchInfoPage)}");
        }

        private async void PrivacyClick(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(PrivacyAndPoliciesPage)}");
        }
    }
}
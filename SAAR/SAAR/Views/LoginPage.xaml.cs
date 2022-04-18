using Newtonsoft.Json;
using RestSharp;
using SAAR.Models;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAAR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        protected bool NumberEnabled = true;
        private string OTPSent = "";

        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            LoginButton.Clicked += LoginButton_Clicked;
            HeaderLable.Text = $"Welcome to{Environment.NewLine}SAAR Mobile App!";
            Progess.Progress = 0;
            OTPFrame.IsVisible = false;
            OPTText.TextChanged += OPTText_TextChanged;
        }

        private void OPTText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 6)
            {
                Button_Clicked(sender, e);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Preferences.Get(CommonClass.SharedKeyMobile, "") != "")
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            Progess.Progress = 0;
            if (CommonClass.ObjToString(MobileNo.Text) == "")
            {
                MobileNo.PlaceholderColor = Color.Red;
                MobileNo.Placeholder = "Enter a Mobile No";
                MobileNo.Focus();
                return;
            }
            Progess.Progress = 0.1;
            if (CommonClass.ObjToString(MobileNo.Text).Length != 10)
            {
                MobileNo.Text = "";
                MobileNo.PlaceholderColor = Color.Red;
                MobileNo.Placeholder = "Only 10 degit Mobile Number Allowed";
                MobileNo.Focus();
                return;
            }
            Progess.Progress = 0.2;
            RestClient client = new RestClient(CommonClass.MobileNoVerify(MobileNo.Text));
            Progess.Progress = 0.3;
            RestRequest request = new RestRequest(Method.GET);
            Progess.Progress = 0.4;
            IRestResponse response = await client.ExecuteAsync(request);
            Progess.Progress = 0.5;
            MstUser user = JsonConvert.DeserializeObject<MstUser>(response.Content);
            Progess.Progress = 0.6;
            if (user == null)
            {
                Progess.Progress = 0;
                MobileNo.Text = "";
                MobileNo.PlaceholderColor = Color.Red;
                MobileNo.Placeholder = "Invalid Mobile Number";
                MobileNo.Focus();
                return;
            }
            else
            {
                NumberEnabled = false;

                Random rand = new Random();
                var sp = rand.Next(111111, 999999);

                OTPSent = (CommonClass.SendOtp(MobileNo.Text, sp.ToString()));

                OTPFrame.IsVisible = true;
                LoginButton.IsVisible = false;
                OPTText.Text = OTPSent;
                OPTText.Focus();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Progess.Progress = 0;
            if (CommonClass.ObjToString(MobileNo.Text) == "")
            {
                MobileNo.PlaceholderColor = Color.Red;
                MobileNo.Placeholder = "Enter a Mobile No";
                MobileNo.Focus();
                return;
            }
            Progess.Progress = 0.1;
            if (CommonClass.ObjToString(MobileNo.Text).Length != 10)
            {
                MobileNo.Text = "";
                MobileNo.PlaceholderColor = Color.Red;
                MobileNo.Placeholder = "Only 10 degit Mobile Number Allowed";
                MobileNo.Focus();
                return;
            }
            Progess.Progress = 0.2;
            RestClient client = new RestClient(CommonClass.MobileNoVerify(MobileNo.Text));
            Progess.Progress = 0.3;
            RestRequest request = new RestRequest(Method.GET);
            Progess.Progress = 0.4;
            IRestResponse response = await client.ExecuteAsync(request);
            Progess.Progress = 0.5;
            MstUser user = JsonConvert.DeserializeObject<MstUser>(response.Content);
            Progess.Progress = 0.6;
            if (user == null)
            {
                Progess.Progress = 0;
                MobileNo.Text = "";
                MobileNo.PlaceholderColor = Color.Red;
                MobileNo.Placeholder = "Invalid Mobile Number";
                MobileNo.Focus();
                return;
            }
            else
            {
                if (OPTText.Text == OTPSent)
                {
                    Preferences.Set(CommonClass.SharedKeyMobile, MobileNo.Text);
                    Preferences.Set(CommonClass.SharedKeyGSTNo, user.Comp_GstNo);
                    Preferences.Set(CommonClass.SharedKeyPartyName, user.Party);
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                }
            }
        }
    }
}
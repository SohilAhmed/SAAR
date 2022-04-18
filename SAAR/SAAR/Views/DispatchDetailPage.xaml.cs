using Newtonsoft.Json;
using RestSharp;
using SAAR.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAAR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DispatchDetailPage : ContentPage
    {
        public List<Sms_TransNew> DispatchPartyData = new List<Sms_TransNew>();

        public DispatchDetailPage()
        {
            InitializeComponent();

            ListD.SelectionMode = ListViewSelectionMode.Single;
            ListD.ItemSelected += ListD_ItemSelected;
        }

        private async void ListD_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Sms_TransNew;

            DispatchBodyInfoPage.InitSetData(Fvno: item.Fvno, Comp_GSTno: item.Comp_GSTno, Bill_No: item.Bill_No);
            await Shell.Current.GoToAsync($"{nameof(DispatchBodyInfoPage)}");
        }

        protected override async void OnAppearing()
        {
            await FillData();
            base.OnAppearing();
        }

        private async Task FillData()
        {
            ListD.IsRefreshing = true;
            string myValue = Preferences.Get("Mobile", "");
            RestClient client = new RestClient(CommonClass.DispatchInfoDetails(MobileNo: myValue, PartyName: CommonClass.DispatchDetailsPartyName, GSTNo: CommonClass.DispatchDetailsCompGstNo));
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            DispatchPartyData = JsonConvert.DeserializeObject<List<Sms_TransNew>>(response.Content);

            if (DispatchPartyData.Count > 0)
            {
                ListD.ItemsSource = DispatchPartyData;
                TotalOuts.Text = $"{DispatchPartyData[0].Comp_Name}{Environment.NewLine}{DispatchPartyData[0].Party}";
                Total.Text = $"Count: {DispatchPartyData.Count}";
            }
            ListD.IsRefreshing = false;
        }
    }
}
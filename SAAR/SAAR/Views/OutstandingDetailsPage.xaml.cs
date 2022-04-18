using Newtonsoft.Json;
using RestSharp;
using SAAR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAAR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OutstandingDetailsPage : ContentPage
    {
        public List<outstandingInfo> OutstandingPartyData = new List<outstandingInfo>();

        public OutstandingDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            FillData();
            base.OnAppearing();
        }

        private async void FillData()
        {
            ListD.IsRefreshing = true;
            string myValue = Preferences.Get("Mobile", "");
            RestClient client = new RestClient(CommonClass.OutstandingDetails(MobileNo: myValue, PartyName: CommonClass.OutstandingDetailsPartyName, GSTNo: CommonClass.OutstandingDetailsCompGstNo));
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            OutstandingPartyData = JsonConvert.DeserializeObject<List<outstandingInfo>>(response.Content);
            ListD.ItemsSource = OutstandingPartyData;
            TotalOuts.Text = $"{OutstandingPartyData[0].Comp_Name}{Environment.NewLine}{OutstandingPartyData[0].Party}";
            Total.Text = $"Total balance: {OutstandingPartyData.Sum(s => s.Due_Amt)}";
            ListD.IsRefreshing = false;
            CommonClass.OutstandingDetailsPartyName = "";
            CommonClass.OutstandingDetailsCompGstNo = "";
        }
    }
}
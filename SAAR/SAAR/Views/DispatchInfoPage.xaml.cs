using Newtonsoft.Json;
using RestSharp;
using Syncfusion.ListView.XForms;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAAR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DispatchInfoPage : ContentPage
    {
        public List<DispatchInfoSummary> DispatchPartyData = new List<DispatchInfoSummary>();
        public string TotalOutstangins = "";

        public DispatchInfoPage()
        {
            InitializeComponent();

            listView2Days.SelectionChanged += ListView_SelectionChanged;
            listView2Days.SelectionMode = Syncfusion.ListView.XForms.SelectionMode.Single;
            listView7Days.SelectionChanged += ListView_SelectionChanged;
            listView7Days.SelectionMode = Syncfusion.ListView.XForms.SelectionMode.Single;
            listViewAllDays.SelectionChanged += ListView_SelectionChanged;
            listViewAllDays.SelectionMode = Syncfusion.ListView.XForms.SelectionMode.Single;
        }

        private async void ListView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            var item = e.AddedItems[0] as DispatchInfoSummary;
            CommonClass.DispatchDetailsPartyName = item.Party;
            CommonClass.DispatchDetailsCompGstNo = item.Comp_GstNo;
            await Shell.Current.GoToAsync($"{nameof(DispatchDetailPage)}");
        }

        protected override void OnAppearing()
        {
            FillData();
            base.OnAppearing();
        }

        private void FillData()
        {
            Last2DaysData();
            Last7DaysData();
            LastAllDaysData();
        }

        private async void Last2DaysData()
        {
            string myValue = Preferences.Get("Mobile", "");
            RestClient client = new RestClient(CommonClass.DispatchInfoSummary(myValue, "2"));
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            List<DispatchInfoSummary> ls = JsonConvert.DeserializeObject<List<DispatchInfoSummary>>(response.Content);
            DispatchPartyData = ls.OrderBy(s => s.Party).ToList();
            Total2DaysOuts.Text = $"Total Dispatch: {DispatchPartyData.Sum(s => s.NetAmount)}";
            listView2Days.ItemsSource = DispatchPartyData;
        }

        private async void Last7DaysData()
        {
            string myValue = Preferences.Get("Mobile", "");
            RestClient client = new RestClient(CommonClass.DispatchInfoSummary(myValue, "7"));
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            List<DispatchInfoSummary> ls = JsonConvert.DeserializeObject<List<DispatchInfoSummary>>(response.Content);
            DispatchPartyData = ls.OrderBy(s => s.Party).ToList();
            Total7DaysOuts.Text = $"Total Dispatch: {DispatchPartyData.Sum(s => s.NetAmount)}";
            listView7Days.ItemsSource = DispatchPartyData;
        }

        private async void LastAllDaysData()
        {
            string myValue = Preferences.Get("Mobile", "");
            RestClient client = new RestClient(CommonClass.DispatchInfoSummary(myValue, "All"));
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            List<DispatchInfoSummary> ls = JsonConvert.DeserializeObject<List<DispatchInfoSummary>>(response.Content);
            DispatchPartyData = ls.OrderBy(s => s.Party).ToList();
            TotalAllDaysOuts.Text = $"Total Dispatch: {DispatchPartyData.Sum(s => s.NetAmount)}";
            listViewAllDays.ItemsSource = DispatchPartyData;
        }
    }

    public class DispatchInfoSummary
    {
        public string Comp_Name { get; set; }
        public string Party { get; set; }
        public string Comp_GstNo { get; set; }
        public decimal NetAmount { get; set; }
    }
}
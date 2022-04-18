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
    public partial class OutstandingsPage : ContentPage
    {
        public List<OustStandDataDisplay> OutstandingPartyData = new List<OustStandDataDisplay>();
        public string TotalOutstangins = "";

        public OutstandingsPage()
        {
            InitializeComponent();

            listView.SelectionChanged += ListView_SelectionChanged;
            listView.SelectionMode = Syncfusion.ListView.XForms.SelectionMode.Single;
        }

        private async void ListView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            var item = e.AddedItems[0] as OustStandDataDisplay;
            CommonClass.OutstandingDetailsPartyName = item.Party;
            CommonClass.OutstandingDetailsCompGstNo = item.Comp_GstNo;
            await Shell.Current.GoToAsync($"{nameof(OutstandingDetailsPage)}");
        }

        protected override void OnAppearing()
        {
            FillData();
            base.OnAppearing();
        }

        private async void FillData()
        {
            string myValue = Preferences.Get("Mobile", "");
            RestClient client = new RestClient(CommonClass.OutstandingSummary(myValue));
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            List<OustStandDataDisplay> ls = JsonConvert.DeserializeObject<List<OustStandDataDisplay>>(response.Content);
            OutstandingPartyData = ls.OrderBy(s => s.Party).ToList();
            TotalOuts.Text = $"Total Outstanding: {OutstandingPartyData.Sum(s => s.Due_Amt)}";
            listView.ItemsSource = OutstandingPartyData;
        }
    }

    public class OustStandDataDisplay
    {
        public string Comp_Name { get; set; }
        public string Party { get; set; }
        public string Comp_GstNo { get; set; }
        public decimal Due_Amt { get; set; }
    }
}
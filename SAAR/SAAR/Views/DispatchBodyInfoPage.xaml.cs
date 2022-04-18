using Newtonsoft.Json;
using RestSharp;
using SAAR.Models;
using SAAR.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAAR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DispatchBodyInfoPage : ContentPage
    {
        public List<Sms_TransNew1> DispatchBodyData = new List<Sms_TransNew1>();

        public DispatchBodyInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            FillData();
            base.OnAppearing();
        }

        private void FillData()
        {
            RestClient client = new RestClient(CommonClass.DispatchBillBodyInfo(Comp_GstNo: data.Comp_GSTno, Fvno: data.Fvno, Bill_No: data.Bill_No));
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var RetData = JsonConvert.DeserializeObject<List<DispatchBodyData>>(response.Content);

            ListD.ItemsSource = RetData.Select(s => s.s1).ToList();
            Bill_Date.Text = RetData[0].s1.Bill_Date.Value.ToString("dd/MMM/yyyy");
            Bill_No.Text = RetData[0].s1.Bill_No;
            CompanyName.Text = RetData[0].CompanyName;
            PartyName.Text = RetData[0].PartyName;
            Amount.Text = RetData.Sum(w => w.s1.Amount ?? 0).ToString();
        }

        private static readonly DispatchDetailsViewModel data = new DispatchDetailsViewModel();

        public static void InitSetData(string Bill_No, string Comp_GSTno, string Fvno)
        {
            data.Bill_No = Bill_No;
            data.Comp_GSTno = Comp_GSTno;
            data.Fvno = Fvno;
        }

        private async void ListD_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Sms_TransNew1;
            PackInfoPage.InitData(CaseNo: item.Caseno, Comp_GSTno: item.Comp_GSTno, PartyName.Text, BillNo: item.Bill_No, BillDate: item.Bill_Date);
            await Shell.Current.GoToAsync($"{nameof(PackInfoPage)}");
        }
    }

    public class DispatchBodyData
    {
        public Sms_TransNew1 s1 { get; set; }
        public string CompanyName { get; set; }
        public string PartyName { get; set; }
    }
}
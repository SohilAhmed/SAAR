using Newtonsoft.Json;
using RestSharp;
using SAAR.Models;
using SAAR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAAR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PackInfoPage : ContentPage
    {
        private List<PackInfo> PackInfoData = new List<PackInfo>();

        public PackInfoPage()
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
            RestClient client = new RestClient(CommonClass.PackInfoDetails(Comp_GSTno: Data.Comp_GSTno, CaseNo: Data.CaseNo, Party: Data.Party));
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            PackInfoData = JsonConvert.DeserializeObject<List<PackInfo>>(response.Content);
            ListD.ItemsSource = PackInfoData;
            CompanyName.Text = PackInfoData[0].Comp_Name;
            PartyName.Text = PackInfoData[0].Party;
            Bill_Date.Text = Data.BillDate.Value.ToString("dd/MMM/yyyy");
            Bill_No.Text = Data.BillNo;
            CaseNo.Text = PackInfoData[0].Caseno;
            TotalQty.Text = PackInfoData.Sum(s => s.Qty ?? 0).ToString();
            TotalPcs.Text = PackInfoData.Sum(s => s.No_Pcs ?? 0).ToString();
        }

        private static PackInfoViewModel Data = new PackInfoViewModel();

        public static void InitData(string CaseNo, string Comp_GSTno, string Party, DateTime? BillDate, string BillNo)
        {
            Data.CaseNo = CaseNo;
            Data.Comp_GSTno = Comp_GSTno;
            Data.Party = Party;
            Data.BillDate = BillDate;
            Data.BillNo = BillNo;
        }
    }
}
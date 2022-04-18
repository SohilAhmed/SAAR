using SAAR.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SAAR
{
    public partial class AppShell : Shell
    {
        public bool NavItemsVisible = false;
        public string MobileNo { get; set; }
        public string CompanyName { get; set; }
        public string GSTNO { get; set; }

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
            GetData();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(OutstandingsPage), typeof(OutstandingsPage));
            Routing.RegisterRoute(nameof(OutstandingDetailsPage), typeof(OutstandingDetailsPage));
            Routing.RegisterRoute(nameof(DispatchInfoPage), typeof(DispatchInfoPage));
            Routing.RegisterRoute(nameof(DispatchDetailPage), typeof(DispatchDetailPage));
            Routing.RegisterRoute(nameof(DispatchBodyInfoPage), typeof(DispatchBodyInfoPage));
            Routing.RegisterRoute(nameof(PackInfoPage), typeof(PackInfoPage));
            Routing.RegisterRoute(nameof(PrivacyAndPoliciesPage), typeof(PrivacyAndPoliciesPage));
        }

        private void GetData()
        {
            CompanyName = Preferences.Get(CommonClass.SharedKeyPartyName, "");
            MobileNo = Preferences.Get(CommonClass.SharedKeyMobile, "");
            GSTNO = Preferences.Get(CommonClass.SharedKeyGSTNo, "");
        }
    }
}
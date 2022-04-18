using Xamarin.Forms;

namespace SAAR
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDY5OTM1QDMxMzkyZTMyMmUzMEdGblNuVjU1empoUFdLZUlmeERpQVJIVW1vdGpLc25jM0srNWhhWU05M1k9");

            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
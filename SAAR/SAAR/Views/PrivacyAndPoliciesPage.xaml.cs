using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAAR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrivacyAndPoliciesPage : ContentPage
    {
        public PrivacyAndPoliciesPage()
        {
            InitializeComponent();
            this.Title = "Privacy & Policy";
        }
    }
}
using Android.App;
using Android.OS;
using System.Threading;

namespace SAAR.Droid
{
    [Activity(Label = "SAAR", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = false)]
    public class SplashScreanActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Thread.Sleep(5 * 000);
            StartActivity(typeof(MainActivity));
        }
    }
}
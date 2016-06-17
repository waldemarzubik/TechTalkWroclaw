using Android.App;
using Android.OS;
using Android.Support.V7.App;
using TechTalk.Interfaces;
using System.Threading.Tasks;
using TechTalk.ViewModels;
using TechTalk.Droid.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace TechTalk.Droid.Views
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Epam.TechTalk.Splash")]
    public class SplashView : AppCompatActivity
    {
        private INavigation NavigationService => ServiceLocator.Current.GetInstance<INavigation>();

        private IActivityLifeTimeMonitor ActivityLifeTimeMonitor => ServiceLocator.Current.GetInstance<IActivityLifeTimeMonitor>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ActivityLifeTimeMonitor.Activity = this;
            SetContentView(Resource.Layout.SplashView);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Task.Run(async () =>
            {
                await Task.Delay(1500);
                NavigationService.NavigateTo<IMainViewModel>();
            });
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (ActivityLifeTimeMonitor.Activity == this)
            {
                ActivityLifeTimeMonitor.Activity = null;
            }
        }
    }
}
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using GalaSoft.MvvmLight.Ioc;
using TechTalk.Interfaces;
using System.Threading.Tasks;
using TechTalk.ViewModels;

namespace TechTalk.Droid.Views
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Epam.TechTalk.Splash")]
    public class SplashView : AppCompatActivity
    {
        private INavigation NavigationService => SimpleIoc.Default.GetInstance<INavigation>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashView);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Task.Run(async () =>
            {
                await Task.Delay(3000);
                NavigationService.NavigateTo<IMainViewModel>();
            });
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
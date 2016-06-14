using Android.App;
using TechTalk.ViewModels.Implementation;

namespace TechTalk.Droid.Views
{
    [Activity]
    public class MainView : ActivityBase<MainViewModel>
    {
        public MainView() : base(Resource.Layout.MainView, Resource.Layout.Toolbar)
        {
        }
    }
}
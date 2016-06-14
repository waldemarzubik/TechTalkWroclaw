using Android.App;
using TechTalk.ViewModels;

namespace TechTalk.Droid.Views
{
    [Activity]
    public class MainView : ActivityBase<IMainViewModel>
    {
        public MainView() : base(Resource.Layout.MainView, Resource.Layout.Toolbar)
        {
        }
    }
}
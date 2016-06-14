using Android.App;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using TechTalk.ViewModels;
using TechTalk.Droid.Interfaces;
using TechTalk.ViewModel;

namespace TechTalk.Droid.Views
{
    [Activity(LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class MainView : ActivityBase<IMainViewModel>, IDrawerHandler
    {
        private DrawerLayout _drawer;
        private ActionBarDrawerToggle _drawerToggle;

        private DrawerLayout Drawer { get { return _drawer ?? (_drawer = FindViewById<DrawerLayout>(Resource.Id.drawerLayout)); } }

        public MainView() : base(Resource.Layout.MainView, Resource.Id.toolbar)
        {
        }

        public DrawerLayout DrawerLayout { get { return Drawer; } }

        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ViewModel.NavigationService.NavigateTo<IMainMenuViewModel>();
        }

        protected override void OnCreateToolbar()
        {
            base.OnCreateToolbar();
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.Title = string.Empty;
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _drawerToggle = new ActionBarDrawerToggle(this, DrawerLayout, toolbar, 0, 0);
            _drawerToggle.DrawerIndicatorEnabled = true;
            DrawerLayout.AddDrawerListener(_drawerToggle);
            _drawerToggle.SyncState();
        }
    }
}
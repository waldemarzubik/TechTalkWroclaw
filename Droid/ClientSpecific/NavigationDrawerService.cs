using System;
using Android.Views;
using TechTalk.Droid.Interfaces;

namespace TechTalk.Droid.ClientSpecific
{
    public class NavigationDrawerService : INavigationDrawer
    {
        private readonly IActivityLifeTimeMonitor _activityLifeTimeMonitor;

        public NavigationDrawerService(IActivityLifeTimeMonitor activityLifeTimeMonitor)
        {
            _activityLifeTimeMonitor = activityLifeTimeMonitor;
        }

        public void Close()
        {
            (_activityLifeTimeMonitor.Activity as IDrawerHandler)?.DrawerLayout.CloseDrawers();
        }

        public void Open()
        {
            (_activityLifeTimeMonitor.Activity as IDrawerHandler)?.DrawerLayout.OpenDrawer((int)GravityFlags.Start);
        }
    }
}
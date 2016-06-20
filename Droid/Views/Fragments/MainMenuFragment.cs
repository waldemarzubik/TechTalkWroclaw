using System;
using Android.Support.Design.Widget;
using TechTalk.ViewModel;
namespace TechTalk.Droid
{
    public class MainMenuFragment : FragmentBase<IMainMenuViewModel>
    {
        private NavigationView _navigationView;

        private NavigationView NavigationView { get { return _navigationView ?? (_navigationView = Activity.FindViewById<NavigationView>(Resource.Id.navigationView)); } }

        public MainMenuFragment() : base(Resource.Layout.MainMenuView)
        {
        }

        public override void OnViewCreated(Android.Views.View view, Android.OS.Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            NavigationView.ItemIconTintList = null;
            var menu = NavigationView.Menu;
            for (int i = 0; i < ViewModel.Menu.Count; i++)
            {
                var item = ViewModel.Menu[i];
                menu.Add(0, i, i, new Java.Lang.String(item.Substring(0, 1).ToUpper() + item.Substring(1)));
                menu.GetItem(i).SetIcon(GetIcon(item));
            }
        }

        private int GetIcon(string value)
        {
            switch (value.ToLower())
            {
                case "gallery":
                    return Resource.Drawable.ic_gallery;
                case "cool option":
                    return Resource.Drawable.ic_cool;
                case "for noobs":
                    return Resource.Drawable.ic_noob;
                case "rush b":
                    return Resource.Drawable.ic_rush;
                case "about":
                    return Resource.Drawable.ic_about;
                default:
                    throw new ArgumentException("Invalid option");
            }
        }
    }
}


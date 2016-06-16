using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using TechTalk.Consts;
using TechTalk.Droid.Interfaces;
using TechTalk.Interfaces;
using TechTalk.ViewModels;

namespace TechTalk.Droid.ClientSpecific
{
    public class NavigationService : INavigation
    {
        private readonly Dictionary<Type, Type> _pages;
        private readonly IActivityLifeTimeMonitor _activityLifeTimeMonitor;
        private readonly Dictionary<Type, Tuple<Type, int>> _customMappings;
        private readonly ITransitionService _transitionService;
        private readonly INavigationDrawer _navigationDrawer;

        public NavigationService(IActivityLifeTimeMonitor activityLifeTimeMonitor,
                                 ITransitionService transitionService,
                                 INavigationDrawer navigationDrawer,
                                 Dictionary<Type, Type> pages,
                                 Dictionary<Type, Tuple<Type, int>> customMappings)
        {
            _activityLifeTimeMonitor = activityLifeTimeMonitor;
            _transitionService = transitionService;
            _navigationDrawer = navigationDrawer;
            _pages = pages;
            _customMappings = customMappings;
        }

        private Type CurrentPage
        {
            get
            {
                lock (_pages)
                {
                    var item = _pages.FirstOrDefault(i => i.Value == _activityLifeTimeMonitor.Activity.GetType());
                    return item.Key;
                }
            }
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo<T>() where T : IBaseViewModel
        {
            InternalNavigation<T, object>(null);
        }

        public void NavigateTo<T, G>(G parameter) where T : IBaseViewModel
        {
            InternalNavigation<T, G>(parameter);
        }

        private void InternalNavigation<T, G>(G parameter) where T : IBaseViewModel
        {
            lock (_pages)
            {
                var type = _pages[typeof(T)];
                var currentActivity = _activityLifeTimeMonitor.Activity;
                if (_customMappings.ContainsKey(typeof(T)))
                {
                    var mapping = _customMappings[typeof(T)];
                    //jestesmy juz na odpowiedniej aktywnosci, nawigacja do nowej aktywnosci nie jest potrzebna
					//English, mf, do you speak it?
                    if (mapping.Item1 == CurrentPage)
                    {
                        ShowFragment(type, mapping.Item2, parameter);
                        _navigationDrawer.Close();
                    }
                    return;
                }
                using (var intent = GetIntent(type, parameter))
                {
                    if (_transitionService.IsTransitionInfoAvailable)
                    {
                        var options = Android.App.ActivityOptions.MakeSceneTransitionAnimation(currentActivity, _transitionService.GetTransitionInfo());
                        currentActivity.StartActivity(intent, options.ToBundle());
                        return;
                    }
                    currentActivity.StartActivity(intent);
                }
            }
        }

        private Intent GetIntent(Type type, object parameter)
        {
            var intent = new Intent(_activityLifeTimeMonitor.Activity, type);
            if (parameter != null)
            {
                intent.PutExtra(ApplicationConsts.P_NAVIGATION_PARAM, parameter.ToString());
            }
            return intent;
        }

        private void ShowFragment(Type fragmentType, int container, object paramter)
        {
            var fragmentManager = _activityLifeTimeMonitor.Activity.SupportFragmentManager;
            var fragment = fragmentManager.Fragments != null ? fragmentManager.Fragments.FirstOrDefault(item => item != null && item.GetType() == fragmentType) : null;
            if (fragment == null)
            {
                fragment = Activator.CreateInstance(fragmentType) as Fragment;
                Bundle bundle = null;
                if (paramter != null)
                {
                    bundle = new Bundle();
                    bundle.PutString(ApplicationConsts.P_NAVIGATION_PARAM, paramter.ToString());
                }
                fragment.Arguments = bundle;
            }
            var fragmentTransaction = fragmentManager.BeginTransaction();
            if (fragment.IsAdded)
            {
                fragmentTransaction.Show(fragment);
            }
            else
            {
                fragmentTransaction.Replace(container, fragment);
            }
            fragmentTransaction.CommitAllowingStateLoss();
        }
    }
}
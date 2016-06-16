using System;
using Android.Content;
using TechTalk.Consts;
using Microsoft.Practices.ServiceLocation;
using TechTalk.Droid.Interfaces;
using Android.OS;

namespace TechTalk.Droid.Extensions
{
    public static class IntentExtensions
    {
        public static object GetNavigationParamter(this Intent intent)
        {
            var key = intent?.GetStringExtra(ApplicationConsts.P_NAVIGATION_PARAM);
            if (!string.IsNullOrEmpty(key))
            {
                var holder = ServiceLocator.Current.GetInstance<IParamsHolder>();
                return holder.GetParameter<object>(key);
            }
            return null;
        }

        public static object GetNavigationParamter(this Bundle bundle)
        {
            if (bundle != null && bundle.ContainsKey(ApplicationConsts.P_NAVIGATION_PARAM))
            {
                var holder = ServiceLocator.Current.GetInstance<IParamsHolder>();
                return holder.GetParameter<object>(bundle.GetString(ApplicationConsts.P_NAVIGATION_PARAM));
            }
            return null;
        }
    }
}
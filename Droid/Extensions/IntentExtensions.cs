using System;
using Android.Content;
using TechTalk.Consts;

namespace TechTalk.Droid.Extensions
{
    public static class IntentExtensions
    {
        public static object GetNavigationParamter(this Intent intent)
        {
            return intent?.GetStringExtra(ApplicationConsts.P_NAVIGATION_PARAM);
        }
    }
}
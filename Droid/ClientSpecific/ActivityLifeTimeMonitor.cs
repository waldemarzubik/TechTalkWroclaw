using System;
using Android.Support.V7.App;
using TechTalk.Droid.Interfaces;

namespace TechTalk.Droid.ClientSpecific
{
    public class ActivityLifeTimeMonitor : IActivityLifeTimeMonitor
    {
        public AppCompatActivity Activity
        {
            get; set;
        }
    }
}
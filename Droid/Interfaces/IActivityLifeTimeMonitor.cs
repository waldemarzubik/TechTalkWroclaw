using System;
using Android.Support.V7.App;

namespace TechTalk.Droid.Interfaces
{
    public interface IActivityLifeTimeMonitor
    {
        AppCompatActivity Activity { get; set; }
    }
}
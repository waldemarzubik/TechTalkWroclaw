using System;
using Android.App;
using Android.Content;
using Android.Support.V7.App;

namespace TechTalk.Droid
{
    public interface IServiceConnectionBinder
    {
        event EventHandler<ServiceEventArgs> ConnectionChanged;

        void Bind(Context context);

        void Undbind(Context context);

        void Register<T, G>() where T : AppCompatActivity where G : Service;
    }
}
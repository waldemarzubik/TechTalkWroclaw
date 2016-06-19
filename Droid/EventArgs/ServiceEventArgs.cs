using System;
using Android.OS;

namespace TechTalk.Droid
{
    public sealed class ServiceEventArgs : EventArgs
    {
        public ServiceEventArgs(Java.Lang.Class type, IBinder service)
        {
            Type = type;
            Service = service;
        }

        public IBinder Service { get; private set; }

        public Java.Lang.Class Type { get; private set; }
    }
}
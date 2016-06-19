using System;
using Android.Content;
using Android.OS;
using TechTalk.Droid.Interfaces;

namespace TechTalk.Droid
{
    public class BoundedServiceConnection : Java.Lang.Object, IBoundedServiceConnection
    {
        public BoundedServiceConnection()
        {
        }

        public BoundedServiceConnection(System.IntPtr handle, Android.Runtime.JniHandleOwnership ownership) : base(handle, ownership)
        {
        }

        public bool IsConnected
        {
            get;
            private set;
        }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            if (ServiceConnected != null)
            {
                IsConnected = true;
                ServiceConnected(this, new ServiceEventArgs(Java.Lang.Class.ForName(name.ClassName), service));
            }
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            if (ServiceDisconnected != null)
            {
                IsConnected = false;
                ServiceDisconnected(this, EventArgs.Empty);
            }
        }

        public event EventHandler<ServiceEventArgs> ServiceConnected;

        public event EventHandler ServiceDisconnected;
    }
}


using System;
using Android.Content;

namespace TechTalk.Droid.Interfaces
{
    public interface IBoundedServiceConnection : IServiceConnection
    {
        bool IsConnected { get; }

        event EventHandler<ServiceEventArgs> ServiceConnected;

        event EventHandler ServiceDisconnected;
    }
}
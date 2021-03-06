﻿using System;
using Android.Content;

namespace TechTalk.Droid
{
    public interface IBoundedServiceConnection : IServiceConnection
    {
        bool IsConnected { get; }

        event EventHandler<ServiceEventArgs> ServiceConnected;

        event EventHandler ServiceDisconnected;
    }
}
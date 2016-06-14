using System;
using Android.Util;
using Android.Views;

namespace TechTalk.Droid.Interfaces
{
    public interface ITransitionService
    {
        bool IsTransitionInfoAvailable { get; }

        void SetTransitionInfo(params Tuple<View, string>[] elements);

        Pair[] GetTransitionInfo();
    }
}
using System;
using Android.OS;
using Android.Util;
using TechTalk.Droid.Interfaces;

namespace TechTalk.Droid.ClientSpecific
{
    public class TransitionService : ITransitionService
    {
        private Pair[] _transitionInfo;

        public bool IsTransitionInfoAvailable
        {
            get
            {
                return Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop && _transitionInfo != null;
            }
        }

        public void SetTransitionInfo(params Tuple<Android.Views.View, string>[] elements)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
            {
                return;
            }
            if ((elements != null) && (elements.Length > 0))
            {
                _transitionInfo = new Pair[elements.Length];

                for (int i = 0; i < elements.Length; i++)
                {
                    _transitionInfo[i] = Pair.Create(elements[i].Item1, elements[i].Item2);
                }
            }
        }

        public Pair[] GetTransitionInfo()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
            {
                return null;
            }
            try
            {
                return _transitionInfo;
            }
            finally
            {
                _transitionInfo = null;
            }
        }
    }
}
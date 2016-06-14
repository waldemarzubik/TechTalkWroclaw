using System;
using Android.App;
using Android.Runtime;

namespace TechTalk.Droid
{
    [Application(Icon = "@mipmap/ic_launcher", Label = "TechTalk#2")]
    public class App : Application
    {
        #region Properties

        public ViewModelLocator ViewModelLocator => _viewModelLocator;

        #endregion

        public App()
        {
        }

        public App(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            SafeCreateViewModelLocator();
        }

        private void SafeCreateViewModelLocator()
        {
            if (_viewModelLocator == null)
            {
                lock (_lock)
                {
                    if (_viewModelLocator == null)
                    {
                        _viewModelLocator = new ViewModelLocator();
                    }
                }
            }
        }

        #region Private fields

        private static readonly object _lock = new object();
        private static ViewModelLocator _viewModelLocator;

        #endregion
    }
}
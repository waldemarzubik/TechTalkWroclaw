using System;
using Android.OS;
using Android.Support.V7.App;
using TechTalk.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Android.Graphics;
using Android.App;
using TechTalk.Droid.Extensions;
using TechTalk.Droid.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace TechTalk.Droid
{
    public abstract class ActivityBase<T> : AppCompatActivity where T : IBaseViewModel
    {
        private readonly int _layoutResId;
        private readonly int _toolbarResId;

        private IActivityLifeTimeMonitor ActivityLifeTimeMonitor { get; set; }

        protected T ViewModel { get; private set; }

        protected ActivityBase(int layoutResId, int toolbarResId = 0)
        {
            _layoutResId = layoutResId;
            _toolbarResId = toolbarResId;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                OnCreateTransitions();
            }

            ActivityLifeTimeMonitor = ServiceLocator.Current.GetInstance<IActivityLifeTimeMonitor>();
            ViewModel = ServiceLocator.Current.GetInstance<T>();
            base.OnCreate(savedInstanceState);
            ActivityLifeTimeMonitor.Activity = this;
            SetContentView(_layoutResId);

            ViewModel.OnInitialize(Intent.GetNavigationParamter()).ConfigureAwait(false);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                using (var bitmap = BitmapFactory.DecodeResource(Resources, Resource.Mipmap.ic_launcher))
                {
                    var taskDesc = new ActivityManager.TaskDescription("TechTalk#2", bitmap, Resources.GetColor(Resource.Color.LimeGreen));
                    SetTaskDescription(taskDesc);
                    bitmap.Recycle();
                }
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            ActivityLifeTimeMonitor.Activity = this;
            ViewModel.OnNavigatedTo();
        }

        protected override void OnStop()
        {
            ViewModel.OnNavigatingFrom();
            base.OnStop();
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            ActivityLifeTimeMonitor.Activity = this;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (ActivityLifeTimeMonitor.Activity == this)
            {
                ActivityLifeTimeMonitor.Activity = null;
            }
        }

        protected virtual void OnCreateTransitions()
        {
            //override this to use material design transitions
        }
    }
}
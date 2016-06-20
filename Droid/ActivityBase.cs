using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Microsoft.Practices.ServiceLocation;
using TechTalk.Droid.Extensions;
using TechTalk.Droid.Interfaces;
using TechTalk.ViewModels;
using GalaSoft.MvvmLight.Ioc;

namespace TechTalk.Droid
{
    public abstract class ActivityBase<T> : AppCompatActivity where T : IBaseViewModel
    {
        private readonly int _layoutResId;
        private readonly int _toolbarResId;

        private IActivityLifeTimeMonitor ActivityLifeTimeMonitor { get; set; }

        private IServiceConnectionBinder Binder { get; set; }

        protected T ViewModel { get; private set; }

        protected ActivityBase(int layoutResId, int toolbarResId = 0)
        {
            _layoutResId = layoutResId;
            _toolbarResId = toolbarResId;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ActivityLifeTimeMonitor = SimpleIoc.Default.GetInstanceWithoutCaching<IActivityLifeTimeMonitor>();
            Binder = SimpleIoc.Default.GetInstance<IServiceConnectionBinder>();
            ViewModel = ServiceLocator.Current.GetInstance<T>();
            base.OnCreate(savedInstanceState);
            ActivityLifeTimeMonitor.Activity = this;
            SetContentView(_layoutResId);

            ViewModel.OnInitialize(Intent.GetNavigationParamter()).ConfigureAwait(false);
        }

        public override void SetContentView(int layoutResID)
        {
            base.SetContentView(layoutResID);
            OnCreateToolbar();
        }

        protected override void OnStart()
        {
            base.OnStart();
            Binder.Bind(this);
            ActivityLifeTimeMonitor.Activity = this;
            ViewModel.OnNavigatedTo();
        }

        protected override void OnStop()
        {
            ViewModel.OnNavigatingFrom();
            Binder.Undbind(this);
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

        protected virtual void OnCreateToolbar()
        {
            using (var toolbar = FindViewById<Toolbar>(_toolbarResId))
            {
                if (toolbar == null)
                {
                    return;
                }
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }
        }
    }
}
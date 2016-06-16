using System;
using Android.Content;
using Android.OS;
using Android.Views;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TechTalk.Droid.Interfaces;
using TechTalk.ViewModels;
using TechTalk.Droid.Extensions;

namespace TechTalk.Droid
{
    public abstract class FragmentBase<T> : Android.Support.V4.App.Fragment where T : IBaseViewModel
    {
        private readonly int _layoutResId;

        protected T ViewModel { get; private set; }

        protected ITransitionService TransitionService { get; }


        protected FragmentBase(int layoutResId)
        {
            _layoutResId = layoutResId;
            TransitionService = ServiceLocator.Current.GetInstance<ITransitionService>();
        }

        public override void OnAttach(Context context)
        {
            if (!RetainInstance)
            {
                ViewModel = SimpleIoc.Default.GetInstanceWithoutCaching<T>();
            }
            base.OnAttach(context);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ViewModel.OnInitialize(Arguments?.GetNavigationParamter()).ConfigureAwait(false);
        }

        public override void OnStart()
        {
            base.OnStart();
            ViewModel.OnNavigatedTo();
        }

        public override void OnStop()
        {
            ViewModel.OnNavigatingFrom();
            base.OnStop();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(_layoutResId, container, false);
        }
    }
}
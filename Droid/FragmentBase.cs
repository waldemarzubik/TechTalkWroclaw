using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Microsoft.Practices.ServiceLocation;
using TechTalk.Consts;
using TechTalk.Droid.Interfaces;
using TechTalk.ViewModels;

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
                ViewModel = ServiceLocator.Current.GetInstance<T>();
            }
            base.OnAttach(context);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ViewModel.OnInitialize(GetParameter()).ConfigureAwait(false);
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

        protected virtual string GetParameter()
        {
            if (Arguments != null && Arguments.ContainsKey(ApplicationConsts.P_NAVIGATION_PARAM))
            {
                return Arguments.GetString(ApplicationConsts.P_NAVIGATION_PARAM);
            }
            return null;
        }
    }
}
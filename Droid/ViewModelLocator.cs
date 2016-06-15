using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TechTalk.Droid.ClientSpecific;
using TechTalk.Droid.Interfaces;
using TechTalk.Droid.Views;
using TechTalk.Interfaces;
using TechTalk.ViewModels;
using TechTalk.ViewModel;
using TechTalk.Droid.Views.Fragments;

namespace TechTalk.Droid
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        protected override Func<IGalleryService> GalleryServiceFunc => () => new GalleryService(ServiceLocator.Current.GetInstance<IActivityLifeTimeMonitor>());

        protected override Dictionary<Type, Type> NavigationPages
        {
            get
            {
                var dictionary = new Dictionary<Type, Type>();
                dictionary.Add(typeof(IMainViewModel), typeof(MainView));
                dictionary.Add(typeof(IMainMenuViewModel), typeof(MainMenuFragment));
                dictionary.Add(typeof(IGalleryViewModel), typeof(GalleryFragment));
                dictionary.Add(typeof(IPictureViewModel), typeof(PictureView));
                return dictionary;
            }
        }

        private Dictionary<Type, Tuple<Type, int>> CustomMappings
        {
            get
            {
                var dictonary = new Dictionary<Type, Tuple<Type, int>>();
                dictonary.Add(typeof(IGalleryViewModel), new Tuple<Type, int>(typeof(IMainViewModel), Resource.Id.drawerContent));
                dictonary.Add(typeof(IMainMenuViewModel), new Tuple<Type, int>(typeof(IMainViewModel), Resource.Id.navigationDrawer));
                return dictonary;
            }
        }

        protected override Func<INavigation> NavigationServiceFunc => () =>
            new NavigationService(ServiceLocator.Current.GetInstance<IActivityLifeTimeMonitor>(),
                                  ServiceLocator.Current.GetInstance<ITransitionService>(),
                                  ServiceLocator.Current.GetInstance<INavigationDrawer>(),
                                  ServiceLocator.Current.GetInstance<IParamsHolder>(),
                                  NavigationPages, CustomMappings);

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IActivityLifeTimeMonitor, ActivityLifeTimeMonitor>();
            SimpleIoc.Default.Register<ITransitionService, TransitionService>();
            SimpleIoc.Default.Register<INavigationDrawer, NavigationDrawerService>();
            SimpleIoc.Default.Register<IParamsHolder, ParamsHolder>();
        }
    }
}
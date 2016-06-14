using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TechTalk.Droid.ClientSpecific;
using TechTalk.Droid.Interfaces;
using TechTalk.Droid.Views;
using TechTalk.Interfaces;
using TechTalk.ViewModels;

namespace TechTalk.Droid
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        protected override Func<IGalleryService> GalleryServiceFunc => () => new GalleryService();

        protected override Dictionary<Type, Type> NavigationPages
        {
            get
            {
                var dictionary = new Dictionary<Type, Type>();
                dictionary.Add(typeof(IMainViewModel), typeof(MainView));
                return dictionary;
            }
        }

        private Dictionary<Type, Tuple<Type, int>> CustomMappings
        {
            get
            {
                var dictonary = new Dictionary<Type, Tuple<Type, int>>();
                dictonary.Add(typeof(IGalleryViewModel), new Tuple<Type, int>(typeof(IMainViewModel), 0));
                return dictonary;
            }
        }

        protected override Func<INavigation> NavigationServiceFunc => () =>
            new NavigationService(ServiceLocator.Current.GetInstance<IActivityLifeTimeMonitor>(),
                                  ServiceLocator.Current.GetInstance<ITransitionService>(),
                                  NavigationPages, CustomMappings);

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IActivityLifeTimeMonitor, ActivityLifeTimeMonitor>();
            SimpleIoc.Default.Register<ITransitionService, TransitionService>();
        }
    }
}
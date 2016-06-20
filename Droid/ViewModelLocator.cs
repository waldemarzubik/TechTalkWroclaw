using System;
using TechTalk.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using TechTalk.Droid.Interfaces;
using TechTalk.Droid.ClientSpecific;
using TechTalk.ViewModels;
using System.Collections.Generic;
using TechTalk.ViewModel;

namespace TechTalk.Droid
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        protected override Func<IGalleryService> GalleryServiceFunc
        {
            get
            {
                return () => new GalleryServiceProxy(SimpleIoc.Default.GetInstance<IServiceConnectionBinder>());
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

        protected override Func<INavigation> NavigationServiceFunc
        {
            get
            {
                return () => new NavigationService(SimpleIoc.Default.GetInstance<IActivityLifeTimeMonitor>(),
                                                   SimpleIoc.Default.GetInstance<ITransitionService>(),
                                                   SimpleIoc.Default.GetInstance<IParamsHolder>(),
                                                   CustomMappings);

            }
        }

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IActivityLifeTimeMonitor, ActivityLifeTimeMonitor>();
            SimpleIoc.Default.Register<ITransitionService, TransitionService>();
            SimpleIoc.Default.Register<IServiceConnectionBinder, ServiceConnectionBinder>();
            SimpleIoc.Default.Register<IParamsHolder, ParamsHolder>();

            var binder = SimpleIoc.Default.GetInstance<IServiceConnectionBinder>();
            binder.Register<MainView, GalleryServiceService>();
        }
    }
}
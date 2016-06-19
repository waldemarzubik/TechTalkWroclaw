using System;
using TechTalk.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using TechTalk.Droid.Interfaces;
using TechTalk.Droid.ClientSpecific;

namespace TechTalk.Droid
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        protected override Func<IGalleryService> GalleryServiceFunc
        {
            get
            {
                return null;
            }
        }

        protected override Func<INavigation> NavigationServiceFunc
        {
            get
            {
                return () => new NavigationService();
            }
        }

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IActivityLifeTimeMonitor, ActivityLifeTimeMonitor>();
            SimpleIoc.Default.Register<ITransitionService, TransitionService>();
        }
    }
}
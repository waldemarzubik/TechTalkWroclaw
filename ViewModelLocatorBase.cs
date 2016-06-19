using System;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TechTalk.Interfaces;
using TechTalk.ViewModel;
using TechTalk.ViewModels;
using TechTalk.ViewModels.Implementation;
using System.Collections.Generic;

namespace TechTalk
{
    public abstract class ViewModelLocatorBase
    {
        protected abstract Func<INavigation> NavigationServiceFunc { get; }

        protected abstract Func<IGalleryService> GalleryServiceFunc { get; }

        protected ViewModelLocatorBase()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //REGISTERING SERVICES
            SimpleIoc.Default.Register<INavigation>(NavigationServiceFunc);
            //SimpleIoc.Default.Register<IGalleryService>(GalleryServiceFunc);

            //REGISTERING VIEW MODEL
            SimpleIoc.Default.Register<IMainMenuViewModel, MainMenuViewModel>();
            SimpleIoc.Default.Register<IMainViewModel, MainViewModel>();
            SimpleIoc.Default.Register<IGalleryViewModel, GalleryViewModel>();
            SimpleIoc.Default.Register<IPictureViewModel, PictureViewModel>();
        }
    }
}
using System;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using TechTalk.ViewModel;
using TechTalk.ViewModels.Implementation;
using TechTalk.ViewModels;
using GalaSoft.MvvmLight.Views;
using TechTalk.Interfaces;
namespace TechTalk
{
    public abstract class ViewModelLocatorBase
    {
        protected abstract INavigationService NavigationService { get; }

        protected abstract IGalleryService GalleryService { get; }

        protected ViewModelLocatorBase()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<INavigationService>(() => NavigationService);
            SimpleIoc.Default.Register<IGalleryService>(() => GalleryService);

            //REGISTERING VIEW MODEL
            SimpleIoc.Default.Register<IMainMenuViewModel, MainMenuViewModel>();
            SimpleIoc.Default.Register<IMainViewModel, MainViewModel>();
            SimpleIoc.Default.Register<IGalleryViewModel, GalleryViewModel>();
            SimpleIoc.Default.Register<IPictureViewModel, PictureViewModel>();
        }
    }
}
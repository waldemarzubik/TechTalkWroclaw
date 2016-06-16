using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Views;
using TechTalk.Interfaces;

namespace TechTalk.iOS
{
    public sealed class ViewModelLocator : ViewModelLocatorBase
    {
		protected override Func<IGalleryService> GalleryServiceFunc => () => new GalleryService();

		protected override Func<INavigation> NavigationServiceFunc => () => new NavigationService();

        
    }
}
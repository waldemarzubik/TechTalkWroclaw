using System;
using System.Collections.Generic;
using TechTalk.Droid.Views;
using TechTalk.Interfaces;
using TechTalk.ViewModels.Implementation;
using TechTalk.Droid.ClientSpecific;

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
                dictionary.Add(typeof(MainViewModel), typeof(MainView));
                return dictionary;
            }
        }

        protected override Func<INavigation> NavigationServiceFunc => () => new NavigationService(NavigationPages);
    }
}